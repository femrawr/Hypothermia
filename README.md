# Hypothermia
> ⚠️**Discontinued:** Hypothermia has been officially discontinued as of 28 June 2025.

An advance remote administration tool fully controllable by a Discord bot.

## Building
> ⚠️ **Notice:** This is not intended for the average user. Basic scripting knowledge is required.

- Install [golang](https://go.dev/doc/install).
- In the `scripts` folder, change the paths to match your environment.
- In the `config/constants.go` file, replace `BotToken`, `ServerId` and `CategoryId` to your own Discord bot token, server ID, and category ID.
- Those values **MUST** be encrypted. Use `scripts/encrypt.bat` to encrypt them.
- After you have done that, run `scripts/build.bat` and an executable will appear in the `build` folder.

## Policy Compliance
Hypothermia does not violate [GitHub's Active Malware or Exploits Policy](https://docs.github.com/en/site-policy/acceptable-use-policies/github-active-malware-or-exploits). It is fully open sourced serves as a transparent and educational demonstration of how [discordgo](https://github.com/bwmarrin/discordgo) can be used. It is used for researching and understanding long standing vulnerabilities and exploits in Discord and Windows.

> "Note that GitHub allows dual-use content and supports the posting of content that is used for research into vulnerabilities, malware, or exploits, as the publication and distribution of such content has educational value and provides a net benefit to the security community."

> https://docs.github.com/en/site-policy/acceptable-use-policies/github-active-malware-or-exploits

This project complies fully with GitHub's policies by being non-malicious, openly documented, and clearly restricted to lawful and ethical usage.

## Disclaimer
Hypothermia is for cyber security research proof-of-concept project to show how a remote tool can be used with [discordgo](https://github.com/bwmarrin/discordgo).

It is intended for educational and ethical use only. Hypothermia is only to be used on devices you own or have explicit permission to manage. Unauthorized access to computer systems is illegal and unethical. The creator of this tool are not responsible for any misuse or illegal activities conducted using this software. ​Everything you do, you are doing at your own risk and responsibility.