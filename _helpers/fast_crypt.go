package main

import (
	"fmt"
	"os"

	"Hypothermia/src/utils/crypto"
)

func main() {
	if len(os.Args) < 2 {
		fmt.Println("no data provided")
		return
	}

	encrypted := utils_crypto.Encrypt(os.Args[1])
	fmt.Print(encrypted)
}
