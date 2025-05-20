package utils

import (
	"Hypothermia/config"
	"os"
	"os/exec"
	"path/filepath"
	"regexp"
	"strings"
	"syscall"
	"unicode"
)

var vms = [5]string{
	"vmGuestLib.dll",
	"vm3dgl.dll",
	"vboxhook.dll",
	"vboxmrxnp.dll",
	"vmsrvc.dll",
}

var drivers = [7]string{
	"VBoxGuest.sys",
	"VBoxSF.sys",
	"VBoxVideo.sys",
	"vm3dmp.sys",
	"vmhgfs.sys",
	"vmusbmouse.sys",
	"vmsrvc.sys",
}

var processes = [27]string{
	"vmtoolsd.exe",
	"vmwaretray.exe",
	"vmwareuser.exe",
	"fakenet.exe",
	"dumpcap.exe",
	"httpdebuggerui.exe",
	"wireshark.exe",
	"fiddler.exe",
	"vboxservice.exe",
	"df5serv.exe",
	"vboxtray.exe",
	"vmwaretray.exe",
	"ida64.exe",
	"ollydbg.exe",
	"pestudio.exe",
	"vgauthservice.exe",
	"vmacthlp.exe",
	"x96dbg.exe",
	"x32dbg.exe",
	"prl_cc.exe",
	"prl_tools.exe",
	"xenservice.exe",
	"qemu-ga.exe",
	"joeboxcontrol.exe",
	"ksdumperclient.exe",
	"ksdumper.exe",
	"joeboxserver.exe",
}

var vtNames = [9]string{
	"bruno",
	"Harry Johnson",
	"John",
	"Janet Van Dyne",
	"John Doe",
	"Frank",
	"Admin",
	"admin",
	"valiuser",
}

func CheckVMs() bool {
	for _, vm := range vms {
		if _, err := os.Stat("C:\\windows\\system32\\" + vm); os.IsNotExist(err) {
			return false
		}
	}

	return true
}

func CheckDrivers() bool {
	for _, dr := range drivers {
		if _, err := os.Stat("C:\\windows\\system32\\drivers\\" + dr); os.IsNotExist(err) {
			return false
		}
	}

	return true
}

func CheckProcesses() bool {
	cmd := exec.Command("tasklist")
	cmd.SysProcAttr = &syscall.SysProcAttr{
		HideWindow: true,
	}

	out, err := cmd.Output()
	if err != nil {
		return false
	}

	procs := string(out)
	for _, proc := range processes {
		if strings.Contains(procs, proc) {
			return true
		}
	}

	return false
}

func CheckVT() bool {
	path, err := os.Executable()
	if err != nil {
		return false
	}

	path = strings.ToLower(path)
	regex := regexp.MustCompile(config.RealProcName + `(\s*\(\d+\))?\.exe$`)

	for _, name := range vtNames {
		if strings.Contains(path, name) {
			if !regex.MatchString(path) {
				return true
			}

			desktop := filepath.Join(os.Getenv("USERPROFILE"), "Desktop")
			files, err := os.ReadDir(desktop)
			if err != nil {
				return false
			}

			fileCount := len(files)
			if fileCount == 0 {
				return false
			}

			counter := 0
			for _, item := range files {
				if isAllUpper(item.Name()) {
					counter++
				}
			}

			ratio := float64(counter) / float64(fileCount)
			if ratio >= 8.0 {
				return true
			}
		}
	}

	return false
}

func CheckTestMode() bool {
	cmd := exec.Command("bcdedit.exe")
	out, err := cmd.Output()
	if err != nil {
		return false
	}

	outStr := string(out)
	return strings.Contains(outStr, "testsigning") && strings.Contains(outStr, "Yes")
}

func isAllUpper(file string) bool {
	base := filepath.Base(file)
	extention := filepath.Ext(base)
	name := strings.TrimSuffix(base, extention)

	check := false
	for _, char := range name {
		if unicode.IsLetter(char) {
			check = true
			break
		}
	}

	if !check {
		return false
	}

	for _, char := range name {
		if unicode.IsLetter(char) && !unicode.IsUpper(char) {
			return false
		}
	}

	return true
}
