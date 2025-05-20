package utils

import (
	"crypto/sha1"
	"fmt"
	"os/exec"
	"os/user"
	"strings"
	"syscall"
)

const (
	PRODUCT_UUID string = "(Get-CimInstance Win32_ComputerSystemProduct).UUID"
	BIOS_SERIAL  string = "(Get-WmiObject Win32_BIOS).SerialNumber"
	CPU_ID       string = "(Get-WmiObject Win32_Processor).ProcessorId"
	BOARD_SERIAL string = "(Get-WmiObject Win32_BaseBoard).SerialNumber"
)

func GetUserProfile() (*user.User, error) {
	usr, err := user.Current()
	if err != nil {
		return nil, err
	}

	return usr, nil
}

func GetIdentifier() string {
	script := `
		$uuid = (Get-CimInstance Win32_ComputerSystemProduct).UUID
		$bios = (Get-WmiObject Win32_BIOS).SerialNumber
		$cpu  = (Get-WmiObject Win32_Processor).ProcessorId
		$board = (Get-WmiObject Win32_BaseBoard).SerialNumber
		Write-Output "$uuid|$bios|$cpu|$board"
	`

	cmd := exec.Command("powershell", "-Command", script)
	cmd.SysProcAttr = &syscall.SysProcAttr{
		HideWindow: true,
	}

	out, err := cmd.Output()
	if err != nil {
		out = []byte("FAILEDTOGETSTUFFYEA:sob:")
	}

	outStr := strings.TrimSpace(string(out))
	hash := sha1.New()
	hash.Write([]byte(outStr))

	return fmt.Sprintf("%x", hash.Sum(nil))
}
