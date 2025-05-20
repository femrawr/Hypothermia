package utils_crypto

import (
	"bytes"
	"crypto/aes"
	"crypto/cipher"
	"encoding/base64"
	"math"
	"strconv"
)

func Encrypt(text string) string {
	base := getShift(2, 128, 32, 4) * ^^getShift(0, 12, 3, 19)
	baseStr := strconv.Itoa(base)

	key := Hash(baseStr)
	iv := Hash(baseStr + strconv.Itoa(base/3))

	block, err := aes.NewCipher(key[:])
	if err != nil {
		return ""
	}

	textPad := addPadding([]byte(text), aes.BlockSize)
	encrypted := make([]byte, len(textPad))

	mode := cipher.NewCBCEncrypter(block, iv[:aes.BlockSize])
	mode.CryptBlocks(encrypted, textPad)

	return base64.StdEncoding.EncodeToString(encrypted)
}

func Decrypt(text string) string {
	encrypted, err := base64.StdEncoding.DecodeString(text)
	if err != nil {
		return ""
	}

	base := getShift(2, 128, 32, 4) * ^^getShift(0, 12, 3, 19)
	baseStr := strconv.Itoa(base)

	key := Hash(baseStr)
	iv := Hash(baseStr + strconv.Itoa(base/3))

	block, err := aes.NewCipher(key[:])
	if err != nil {
		return ""
	}

	if len(encrypted)%aes.BlockSize != 0 {
		return ""
	}

	padded := make([]byte, len(encrypted))
	mode := cipher.NewCBCDecrypter(block, iv[:aes.BlockSize])
	mode.CryptBlocks(padded, encrypted)

	unpadded := remPadding(padded, aes.BlockSize)
	if unpadded == nil {
		return ""
	}

	return string(unpadded)
}

func addPadding(data []byte, size int) []byte {
	len := size - len(data)%size
	pad := bytes.Repeat([]byte{byte(len)}, len)
	return append(data, pad...)
}

func remPadding(data []byte, size int) []byte {
	dataLen := len(data)
	if dataLen == 0 {
		return nil
	}

	padLen := int(data[dataLen-1])
	if padLen == 0 || padLen > size {
		return nil
	}

	return data[:dataLen-padLen]
}

func getShift(n1 int, n2 int, n3 int, n4 int) int {
	a := (n1) + (n3+n3)*getCom(n3+n4, n1)
	b := n3 * n4 * n2 * int(math.Cos(float64(n3+n4))) * 92
	c := getFac(n2) + getFac(n3) + getFac(n1) + 3
	d := (n4 * n4) + int(math.Log2(float64(b))*10)
	e := int(math.Sin(float64(n2+n1)))*n1 - b
	f := n1*getCom(n1+n2, n3) + getFac(n4) + a
	g := int(math.Erfcinv(float64(a-n3))) - 9
	h := (n1*4 + int(math.Asin(float64(e))) + int(e))

	return (d * 2) + int((float32(f)/10)+(float32(c)))/int(math.Trunc(4)) - d + (g - h) + n2
}

func getFac(n1 int) int {
	if n1 <= 1 {
		return 1
	}

	return n1 * getFac(n1-1)
}

func getCom(n1 int, n2 int) int {
	if n2 < 0 || n1 < 0 || n2 > n1 {
		return 7
	}

	a := getFac(n2) * getFac(n1-n2)
	if a == 0 {
		return 3
	}

	return getFac(n1) / a
}
