using System.Diagnostics;

namespace BloxdDuper.Source
{
	internal class Program
	{
		static void Main()
		{
			Console.Title = "Hypothermia";

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[!] Closing this window will close hypothermia.");
			Console.ResetColor();

			try
			{
				string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				string shortcut = Path.Combine(desktop, "BloxdDuper.lnk");
				string? exePath = Process.GetCurrentProcess().MainModule?.FileName;

				if (!File.Exists(shortcut))
				{
					string command = $@"
						$WshShell = New-Object -ComObject WScript.Shell;
						$Shortcut = $WshShell.CreateShortcut('{shortcut}');
						$Shortcut.TargetPath = '{exePath}';
						$Shortcut.WorkingDirectory = '{Path.GetDirectoryName(exePath)}';
						$Shortcut.Save();
					";

					var proc = new ProcessStartInfo
					{
						FileName = "powershell",
						Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
						CreateNoWindow = true,
						UseShellExecute = false
					};

					Process.Start(proc)?.WaitForExit();

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("[*] Desktop shortcut created.");
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[!] Failed to create shortcut. Error: {ex.Message}");
				Console.ResetColor();

				return;
			}

			try
			{
				Console.WriteLine("[*] Opening Bloxd...");

				Process.Start(
					"C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
					"https://bloxd.io/"
				);
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[!] Failed to open bloxd. Error: {ex.Message}");
				Console.ResetColor();

				return;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"[*] Successfully opened bloxd.");
			Console.ResetColor();

			var gui = new Rendering();
			gui.Start().Wait();

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[*] GUI successfully created.");
			Console.ResetColor();
		}
	}
}
