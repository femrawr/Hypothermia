package utils_crypto

import (
	"crypto/sha512"
	"math"
	"strconv"
)

var (
	magic_str_1 string = "import(\"crpyto/sha512\")"
	magic_str_2 string = "\\\n\\\\\\\\\\\\\\\\\\\\\\3"

	magic_int_1 int = 438 / int(math.Sqrt(48))
	magic_int_2 int = 328 * 37
	magic_int_3 int = 2 / int(math.Sqrt(9))
	magic_int_4 int = 65
)

func Hash(text string) []byte {
	seed := getSeed(text + strconv.Itoa(magic_int_1/magic_int_2+magic_int_3))

	hash1 := sha512.New()
	hash1.Write([]byte(text + strconv.Itoa(seed) + magic_str_1))
	sum1 := hash1.Sum(nil)

	hash2 := sha512.New()
	hash1.Write(sum1)
	sum2 := hash2.Sum(nil)

	seeded := math.Abs(float64(int(sum2[0])) * math.Sqrt(float64(int(sum2[1]))) * float64(seed))
	salted := strconv.Itoa(int(seeded)) + strconv.Itoa(seed*int(math.Sqrt(float64(magic_int_4)*float64(magic_int_3))))

	hash3 := sha512.New()
	hash3.Write([]byte(salted))
	sum3 := hash3.Sum(nil)

	for i := range sum3 {
		sum3[i] = byte(int(sum3[i]) ^ int(math.Sin(float64(i+seed))*math.Sqrt(38)))
	}

	sum := append(sum1, sum2...)
	sum = append(sum, sum3...)

	a, b := getBounds(sum)

	var final []byte
	if a > b {
		final = sum[a:b]
	} else {
		final = append(sum[a:], sum[:b]...)
	}

	if len(final) > 32 {
		final = final[:32]
	} else if len(final) < 32 {
		final = append(final, make([]byte, 32-len(final))...)
	}

	return final
}

func getSeed(str string) int {
	a := sha512.New()
	a.Write([]byte(str + str + magic_str_2))
	b := a.Sum(nil)

	for range 100 {
		a.Reset()
		a.Write(b)
		b = a.Sum(nil)
	}

	return int(math.Abs(float64(int(b[0])<<24 + int(b[1])<<16 + int(b[2])<<8 + int(b[3]))))
}

func getBounds(bytes []byte) (int, int) {
	a := int(bytes[0])<<24 + int(bytes[1])<<16 + int(bytes[2])<<8 + int(bytes[3])
	a = a % len(bytes)

	b := (a + 32) % len(bytes)
	if b <= a {
		b = len(bytes) + b
	}

	return a, b
}
