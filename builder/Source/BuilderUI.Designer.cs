namespace builder
{
	partial class BuilderUI
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			BuildButton = new Button();
			ClearButton = new Button();
			TokenLabel = new Label();
			BotTokenBox = new TextBox();
			textBox2 = new TextBox();
			ServerIdBox = new TextBox();
			ServerIdLabel = new Label();
			CategoryIdBox = new TextBox();
			CategoryIdLabel = new Label();
			ConfigLabel = new Label();
			AntiVmToggle = new CheckBox();
			AntiTestModeToggle = new CheckBox();
			AutoStartToggle = new CheckBox();
			HideFolderToggle = new CheckBox();
			AntiKillToggle = new CheckBox();
			DebugModeToggle = new CheckBox();
			CompilerStatusLabel = new Label();
			ProjectDirBox = new TextBox();
			ProjectDirLabel = new Label();
			DirSearchButton = new Button();
			StartupModeCombo = new ComboBox();
			StartupModeLabel = new Label();
			VariantBox = new TextBox();
			VariantLabel = new Label();
			ModuleDownloadBox = new TextBox();
			ModuleUrlLabel = new Label();
			ModuleNameBox = new TextBox();
			ModuleNameLabel = new Label();
			StartupRegKeyNameBox = new TextBox();
			StartupKeyNameLabel = new Label();
			FolderNameBox = new TextBox();
			FolderNameLabel = new Label();
			RealProcNameBox = new TextBox();
			RealProcNameLabel = new Label();
			FakeProcNameBox = new TextBox();
			FakeProcNameLabel = new Label();
			NoWindowToggle = new CheckBox();
			TrimStringsToggle = new CheckBox();
			BuildOptionsLabel = new Label();
			CmdScriptToggle = new CheckBox();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			SuspendLayout();
			// 
			// BuildButton
			// 
			BuildButton.BackColor = SystemColors.ActiveBorder;
			BuildButton.FlatAppearance.BorderSize = 0;
			BuildButton.FlatStyle = FlatStyle.Flat;
			BuildButton.Font = new Font("Segoe UI", 10F);
			BuildButton.Location = new Point(968, 403);
			BuildButton.Name = "BuildButton";
			BuildButton.Size = new Size(65, 35);
			BuildButton.TabIndex = 0;
			BuildButton.Text = "Build";
			BuildButton.UseVisualStyleBackColor = false;
			BuildButton.Click += Build_Clicked;
			// 
			// ClearButton
			// 
			ClearButton.BackColor = SystemColors.ActiveBorder;
			ClearButton.FlatAppearance.BorderSize = 0;
			ClearButton.FlatStyle = FlatStyle.Flat;
			ClearButton.Font = new Font("Segoe UI", 10F);
			ClearButton.Location = new Point(897, 403);
			ClearButton.Name = "ClearButton";
			ClearButton.Size = new Size(65, 35);
			ClearButton.TabIndex = 1;
			ClearButton.Text = "Reset";
			ClearButton.UseVisualStyleBackColor = false;
			ClearButton.Click += Clear_Clicked;
			// 
			// TokenLabel
			// 
			TokenLabel.AutoSize = true;
			TokenLabel.Font = new Font("Segoe UI", 10F);
			TokenLabel.ForeColor = SystemColors.ControlLightLight;
			TokenLabel.Location = new Point(12, 9);
			TokenLabel.Name = "TokenLabel";
			TokenLabel.Size = new Size(85, 23);
			TokenLabel.TabIndex = 3;
			TokenLabel.Text = "Bot Token";
			// 
			// BotTokenBox
			// 
			BotTokenBox.BackColor = SystemColors.ActiveBorder;
			BotTokenBox.Font = new Font("Segoe UI", 10F);
			BotTokenBox.Location = new Point(12, 35);
			BotTokenBox.Name = "BotTokenBox";
			BotTokenBox.Size = new Size(312, 30);
			BotTokenBox.TabIndex = 7;
			// 
			// textBox2
			// 
			textBox2.BackColor = SystemColors.ActiveBorder;
			textBox2.Font = new Font("Segoe UI", 10F);
			textBox2.Location = new Point(352, 246);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(0, 30);
			textBox2.TabIndex = 8;
			// 
			// ServerIdBox
			// 
			ServerIdBox.BackColor = SystemColors.ActiveBorder;
			ServerIdBox.Font = new Font("Segoe UI", 10F);
			ServerIdBox.Location = new Point(12, 109);
			ServerIdBox.Name = "ServerIdBox";
			ServerIdBox.Size = new Size(312, 30);
			ServerIdBox.TabIndex = 10;
			// 
			// ServerIdLabel
			// 
			ServerIdLabel.AutoSize = true;
			ServerIdLabel.Font = new Font("Segoe UI", 10F);
			ServerIdLabel.ForeColor = SystemColors.ControlLightLight;
			ServerIdLabel.Location = new Point(12, 83);
			ServerIdLabel.Name = "ServerIdLabel";
			ServerIdLabel.Size = new Size(77, 23);
			ServerIdLabel.TabIndex = 9;
			ServerIdLabel.Text = "Server Id";
			// 
			// CategoryIdBox
			// 
			CategoryIdBox.BackColor = SystemColors.ActiveBorder;
			CategoryIdBox.Font = new Font("Segoe UI", 10F);
			CategoryIdBox.Location = new Point(12, 185);
			CategoryIdBox.Name = "CategoryIdBox";
			CategoryIdBox.Size = new Size(312, 30);
			CategoryIdBox.TabIndex = 12;
			// 
			// CategoryIdLabel
			// 
			CategoryIdLabel.AutoSize = true;
			CategoryIdLabel.Font = new Font("Segoe UI", 10F);
			CategoryIdLabel.ForeColor = SystemColors.ControlLightLight;
			CategoryIdLabel.Location = new Point(12, 159);
			CategoryIdLabel.Name = "CategoryIdLabel";
			CategoryIdLabel.Size = new Size(99, 23);
			CategoryIdLabel.TabIndex = 11;
			CategoryIdLabel.Text = "Category Id";
			// 
			// ConfigLabel
			// 
			ConfigLabel.AutoSize = true;
			ConfigLabel.Font = new Font("Segoe UI", 10F);
			ConfigLabel.ForeColor = SystemColors.ControlLightLight;
			ConfigLabel.Location = new Point(12, 316);
			ConfigLabel.Name = "ConfigLabel";
			ConfigLabel.Size = new Size(60, 23);
			ConfigLabel.TabIndex = 13;
			ConfigLabel.Text = "Config";
			// 
			// AntiVmToggle
			// 
			AntiVmToggle.AutoSize = true;
			AntiVmToggle.Checked = true;
			AntiVmToggle.CheckState = CheckState.Checked;
			AntiVmToggle.Font = new Font("Segoe UI", 10F);
			AntiVmToggle.ForeColor = SystemColors.ControlLightLight;
			AntiVmToggle.Location = new Point(17, 342);
			AntiVmToggle.Name = "AntiVmToggle";
			AntiVmToggle.Size = new Size(94, 27);
			AntiVmToggle.TabIndex = 14;
			AntiVmToggle.Text = "Anti VM";
			AntiVmToggle.UseVisualStyleBackColor = true;
			// 
			// AntiTestModeToggle
			// 
			AntiTestModeToggle.AutoSize = true;
			AntiTestModeToggle.Checked = true;
			AntiTestModeToggle.CheckState = CheckState.Checked;
			AntiTestModeToggle.Font = new Font("Segoe UI", 10F);
			AntiTestModeToggle.ForeColor = SystemColors.ControlLightLight;
			AntiTestModeToggle.Location = new Point(17, 375);
			AntiTestModeToggle.Name = "AntiTestModeToggle";
			AntiTestModeToggle.Size = new Size(146, 27);
			AntiTestModeToggle.TabIndex = 15;
			AntiTestModeToggle.Text = "Anti Test Mode";
			AntiTestModeToggle.UseVisualStyleBackColor = true;
			// 
			// AutoStartToggle
			// 
			AutoStartToggle.AutoSize = true;
			AutoStartToggle.Checked = true;
			AutoStartToggle.CheckState = CheckState.Checked;
			AutoStartToggle.Font = new Font("Segoe UI", 10F);
			AutoStartToggle.ForeColor = SystemColors.ControlLightLight;
			AutoStartToggle.Location = new Point(169, 375);
			AutoStartToggle.Name = "AutoStartToggle";
			AutoStartToggle.Size = new Size(109, 27);
			AutoStartToggle.TabIndex = 17;
			AutoStartToggle.Text = "Auto Start";
			AutoStartToggle.UseVisualStyleBackColor = true;
			// 
			// HideFolderToggle
			// 
			HideFolderToggle.AutoSize = true;
			HideFolderToggle.Checked = true;
			HideFolderToggle.CheckState = CheckState.Checked;
			HideFolderToggle.Font = new Font("Segoe UI", 10F);
			HideFolderToggle.ForeColor = SystemColors.ControlLightLight;
			HideFolderToggle.Location = new Point(169, 342);
			HideFolderToggle.Name = "HideFolderToggle";
			HideFolderToggle.Size = new Size(119, 27);
			HideFolderToggle.TabIndex = 16;
			HideFolderToggle.Text = "Hide Folder";
			HideFolderToggle.UseVisualStyleBackColor = true;
			// 
			// AntiKillToggle
			// 
			AntiKillToggle.AutoSize = true;
			AntiKillToggle.Checked = true;
			AntiKillToggle.CheckState = CheckState.Checked;
			AntiKillToggle.Font = new Font("Segoe UI", 10F);
			AntiKillToggle.ForeColor = SystemColors.ControlLightLight;
			AntiKillToggle.Location = new Point(169, 408);
			AntiKillToggle.Name = "AntiKillToggle";
			AntiKillToggle.Size = new Size(90, 27);
			AntiKillToggle.TabIndex = 18;
			AntiKillToggle.Text = "Anti Kill";
			AntiKillToggle.UseVisualStyleBackColor = true;
			// 
			// DebugModeToggle
			// 
			DebugModeToggle.AutoSize = true;
			DebugModeToggle.Font = new Font("Segoe UI", 10F);
			DebugModeToggle.ForeColor = SystemColors.ControlLightLight;
			DebugModeToggle.Location = new Point(364, 408);
			DebugModeToggle.Name = "DebugModeToggle";
			DebugModeToggle.Size = new Size(132, 27);
			DebugModeToggle.TabIndex = 19;
			DebugModeToggle.Text = "Debug Mode";
			DebugModeToggle.UseVisualStyleBackColor = true;
			// 
			// CompilerStatusLabel
			// 
			CompilerStatusLabel.AutoSize = true;
			CompilerStatusLabel.Enabled = false;
			CompilerStatusLabel.Font = new Font("Segoe UI", 10F);
			CompilerStatusLabel.ForeColor = Color.FromArgb(255, 128, 0);
			CompilerStatusLabel.Location = new Point(897, 383);
			CompilerStatusLabel.Name = "CompilerStatusLabel";
			CompilerStatusLabel.Size = new Size(0, 23);
			CompilerStatusLabel.TabIndex = 20;
			CompilerStatusLabel.Visible = false;
			// 
			// ProjectDirBox
			// 
			ProjectDirBox.BackColor = SystemColors.ActiveBorder;
			ProjectDirBox.Font = new Font("Segoe UI", 10F);
			ProjectDirBox.Location = new Point(716, 35);
			ProjectDirBox.Name = "ProjectDirBox";
			ProjectDirBox.Size = new Size(256, 30);
			ProjectDirBox.TabIndex = 22;
			// 
			// ProjectDirLabel
			// 
			ProjectDirLabel.AutoSize = true;
			ProjectDirLabel.Font = new Font("Segoe UI", 10F);
			ProjectDirLabel.ForeColor = SystemColors.ControlLightLight;
			ProjectDirLabel.Location = new Point(716, 9);
			ProjectDirLabel.Name = "ProjectDirLabel";
			ProjectDirLabel.Size = new Size(180, 23);
			ProjectDirLabel.TabIndex = 21;
			ProjectDirLabel.Text = "Main Project Directory";
			// 
			// DirSearchButton
			// 
			DirSearchButton.BackColor = SystemColors.ActiveBorder;
			DirSearchButton.FlatAppearance.BorderSize = 0;
			DirSearchButton.FlatStyle = FlatStyle.Flat;
			DirSearchButton.Font = new Font("Segoe UI", 10F);
			DirSearchButton.Location = new Point(978, 34);
			DirSearchButton.Name = "DirSearchButton";
			DirSearchButton.Size = new Size(50, 30);
			DirSearchButton.TabIndex = 23;
			DirSearchButton.Text = "...";
			DirSearchButton.UseVisualStyleBackColor = false;
			DirSearchButton.Click += SearchDir_Clicked;
			// 
			// StartupModeCombo
			// 
			StartupModeCombo.BackColor = SystemColors.ActiveBorder;
			StartupModeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			StartupModeCombo.Font = new Font("Segoe UI", 10F);
			StartupModeCombo.FormattingEnabled = true;
			StartupModeCombo.Items.AddRange(new object[] { "None", "Run incompatible file", "Run module", "Delete original file" });
			StartupModeCombo.Location = new Point(716, 109);
			StartupModeCombo.Name = "StartupModeCombo";
			StartupModeCombo.Size = new Size(312, 31);
			StartupModeCombo.TabIndex = 24;
			StartupModeCombo.SelectedIndexChanged += StarupMode_Changed;
			// 
			// StartupModeLabel
			// 
			StartupModeLabel.AutoSize = true;
			StartupModeLabel.Font = new Font("Segoe UI", 10F);
			StartupModeLabel.ForeColor = SystemColors.ControlLightLight;
			StartupModeLabel.Location = new Point(716, 84);
			StartupModeLabel.Name = "StartupModeLabel";
			StartupModeLabel.Size = new Size(114, 23);
			StartupModeLabel.TabIndex = 25;
			StartupModeLabel.Text = "Startup Mode";
			// 
			// VariantBox
			// 
			VariantBox.BackColor = SystemColors.ActiveBorder;
			VariantBox.Font = new Font("Segoe UI", 10F);
			VariantBox.Location = new Point(12, 265);
			VariantBox.Name = "VariantBox";
			VariantBox.Size = new Size(312, 30);
			VariantBox.TabIndex = 27;
			// 
			// VariantLabel
			// 
			VariantLabel.AutoSize = true;
			VariantLabel.Font = new Font("Segoe UI", 10F);
			VariantLabel.ForeColor = SystemColors.ControlLightLight;
			VariantLabel.Location = new Point(12, 239);
			VariantLabel.Name = "VariantLabel";
			VariantLabel.Size = new Size(128, 23);
			VariantLabel.TabIndex = 26;
			VariantLabel.Text = "Custom Variant";
			// 
			// ModuleDownloadBox
			// 
			ModuleDownloadBox.BackColor = SystemColors.ActiveBorder;
			ModuleDownloadBox.Enabled = false;
			ModuleDownloadBox.Font = new Font("Segoe UI", 10F);
			ModuleDownloadBox.Location = new Point(716, 190);
			ModuleDownloadBox.Name = "ModuleDownloadBox";
			ModuleDownloadBox.Size = new Size(312, 30);
			ModuleDownloadBox.TabIndex = 29;
			ModuleDownloadBox.Visible = false;
			// 
			// ModuleUrlLabel
			// 
			ModuleUrlLabel.AutoSize = true;
			ModuleUrlLabel.Enabled = false;
			ModuleUrlLabel.Font = new Font("Segoe UI", 10F);
			ModuleUrlLabel.ForeColor = SystemColors.ControlLightLight;
			ModuleUrlLabel.Location = new Point(716, 164);
			ModuleUrlLabel.Name = "ModuleUrlLabel";
			ModuleUrlLabel.Size = new Size(185, 23);
			ModuleUrlLabel.TabIndex = 28;
			ModuleUrlLabel.Text = "Module Download URL";
			ModuleUrlLabel.Visible = false;
			// 
			// ModuleNameBox
			// 
			ModuleNameBox.BackColor = SystemColors.ActiveBorder;
			ModuleNameBox.Enabled = false;
			ModuleNameBox.Font = new Font("Segoe UI", 10F);
			ModuleNameBox.Location = new Point(716, 265);
			ModuleNameBox.Name = "ModuleNameBox";
			ModuleNameBox.Size = new Size(312, 30);
			ModuleNameBox.TabIndex = 31;
			ModuleNameBox.Visible = false;
			// 
			// ModuleNameLabel
			// 
			ModuleNameLabel.AutoSize = true;
			ModuleNameLabel.Enabled = false;
			ModuleNameLabel.Font = new Font("Segoe UI", 10F);
			ModuleNameLabel.ForeColor = SystemColors.ControlLightLight;
			ModuleNameLabel.Location = new Point(716, 239);
			ModuleNameLabel.Name = "ModuleNameLabel";
			ModuleNameLabel.Size = new Size(119, 23);
			ModuleNameLabel.TabIndex = 30;
			ModuleNameLabel.Text = "Module Name";
			ModuleNameLabel.Visible = false;
			// 
			// StartupRegKeyNameBox
			// 
			StartupRegKeyNameBox.BackColor = SystemColors.ActiveBorder;
			StartupRegKeyNameBox.Font = new Font("Segoe UI", 10F);
			StartupRegKeyNameBox.Location = new Point(364, 265);
			StartupRegKeyNameBox.Name = "StartupRegKeyNameBox";
			StartupRegKeyNameBox.Size = new Size(312, 30);
			StartupRegKeyNameBox.TabIndex = 39;
			// 
			// StartupKeyNameLabel
			// 
			StartupKeyNameLabel.AutoSize = true;
			StartupKeyNameLabel.Font = new Font("Segoe UI", 10F);
			StartupKeyNameLabel.ForeColor = SystemColors.ControlLightLight;
			StartupKeyNameLabel.Location = new Point(364, 239);
			StartupKeyNameLabel.Name = "StartupKeyNameLabel";
			StartupKeyNameLabel.Size = new Size(213, 23);
			StartupKeyNameLabel.TabIndex = 38;
			StartupKeyNameLabel.Text = "Startup Registry Key Name";
			// 
			// FolderNameBox
			// 
			FolderNameBox.BackColor = SystemColors.ActiveBorder;
			FolderNameBox.Font = new Font("Segoe UI", 10F);
			FolderNameBox.Location = new Point(364, 185);
			FolderNameBox.Name = "FolderNameBox";
			FolderNameBox.Size = new Size(312, 30);
			FolderNameBox.TabIndex = 37;
			// 
			// FolderNameLabel
			// 
			FolderNameLabel.AutoSize = true;
			FolderNameLabel.Font = new Font("Segoe UI", 10F);
			FolderNameLabel.ForeColor = SystemColors.ControlLightLight;
			FolderNameLabel.Location = new Point(364, 159);
			FolderNameLabel.Name = "FolderNameLabel";
			FolderNameLabel.Size = new Size(108, 23);
			FolderNameLabel.TabIndex = 36;
			FolderNameLabel.Text = "Folder Name";
			// 
			// RealProcNameBox
			// 
			RealProcNameBox.BackColor = SystemColors.ActiveBorder;
			RealProcNameBox.Font = new Font("Segoe UI", 10F);
			RealProcNameBox.Location = new Point(364, 109);
			RealProcNameBox.Name = "RealProcNameBox";
			RealProcNameBox.Size = new Size(312, 30);
			RealProcNameBox.TabIndex = 35;
			// 
			// RealProcNameLabel
			// 
			RealProcNameLabel.AutoSize = true;
			RealProcNameLabel.Font = new Font("Segoe UI", 10F);
			RealProcNameLabel.ForeColor = SystemColors.ControlLightLight;
			RealProcNameLabel.Location = new Point(364, 83);
			RealProcNameLabel.Name = "RealProcNameLabel";
			RealProcNameLabel.Size = new Size(155, 23);
			RealProcNameLabel.TabIndex = 34;
			RealProcNameLabel.Text = "Real Process Name";
			// 
			// FakeProcNameBox
			// 
			FakeProcNameBox.BackColor = SystemColors.ActiveBorder;
			FakeProcNameBox.Font = new Font("Segoe UI", 10F);
			FakeProcNameBox.Location = new Point(364, 35);
			FakeProcNameBox.Name = "FakeProcNameBox";
			FakeProcNameBox.Size = new Size(312, 30);
			FakeProcNameBox.TabIndex = 33;
			// 
			// FakeProcNameLabel
			// 
			FakeProcNameLabel.AutoSize = true;
			FakeProcNameLabel.Font = new Font("Segoe UI", 10F);
			FakeProcNameLabel.ForeColor = SystemColors.ControlLightLight;
			FakeProcNameLabel.Location = new Point(364, 9);
			FakeProcNameLabel.Name = "FakeProcNameLabel";
			FakeProcNameLabel.Size = new Size(156, 23);
			FakeProcNameLabel.TabIndex = 32;
			FakeProcNameLabel.Text = "Fake Process Name";
			// 
			// NoWindowToggle
			// 
			NoWindowToggle.AutoSize = true;
			NoWindowToggle.Checked = true;
			NoWindowToggle.CheckState = CheckState.Checked;
			NoWindowToggle.Font = new Font("Segoe UI", 10F);
			NoWindowToggle.ForeColor = SystemColors.ControlLightLight;
			NoWindowToggle.Location = new Point(364, 375);
			NoWindowToggle.Name = "NoWindowToggle";
			NoWindowToggle.Size = new Size(122, 27);
			NoWindowToggle.TabIndex = 42;
			NoWindowToggle.Text = "No Window";
			NoWindowToggle.UseVisualStyleBackColor = true;
			// 
			// TrimStringsToggle
			// 
			TrimStringsToggle.AutoSize = true;
			TrimStringsToggle.Checked = true;
			TrimStringsToggle.CheckState = CheckState.Checked;
			TrimStringsToggle.Font = new Font("Segoe UI", 10F);
			TrimStringsToggle.ForeColor = SystemColors.ControlLightLight;
			TrimStringsToggle.Location = new Point(364, 342);
			TrimStringsToggle.Name = "TrimStringsToggle";
			TrimStringsToggle.Size = new Size(121, 27);
			TrimStringsToggle.TabIndex = 41;
			TrimStringsToggle.Text = "Trim Strings";
			TrimStringsToggle.UseVisualStyleBackColor = true;
			// 
			// BuildOptionsLabel
			// 
			BuildOptionsLabel.AutoSize = true;
			BuildOptionsLabel.Font = new Font("Segoe UI", 10F);
			BuildOptionsLabel.ForeColor = SystemColors.ControlLightLight;
			BuildOptionsLabel.Location = new Point(359, 316);
			BuildOptionsLabel.Name = "BuildOptionsLabel";
			BuildOptionsLabel.Size = new Size(113, 23);
			BuildOptionsLabel.TabIndex = 40;
			BuildOptionsLabel.Text = "Build Options";
			// 
			// CmdScriptToggle
			// 
			CmdScriptToggle.AutoSize = true;
			CmdScriptToggle.Font = new Font("Segoe UI", 10F);
			CmdScriptToggle.ForeColor = SystemColors.ControlLightLight;
			CmdScriptToggle.Location = new Point(896, 370);
			CmdScriptToggle.Name = "CmdScriptToggle";
			CmdScriptToggle.Size = new Size(116, 27);
			CmdScriptToggle.TabIndex = 43;
			CmdScriptToggle.Text = "Cmd Script";
			CmdScriptToggle.UseVisualStyleBackColor = true;
			// 
			// BuilderUI
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.WindowFrame;
			ClientSize = new Size(1045, 450);
			Controls.Add(CmdScriptToggle);
			Controls.Add(NoWindowToggle);
			Controls.Add(TrimStringsToggle);
			Controls.Add(BuildOptionsLabel);
			Controls.Add(StartupRegKeyNameBox);
			Controls.Add(StartupKeyNameLabel);
			Controls.Add(FolderNameBox);
			Controls.Add(FolderNameLabel);
			Controls.Add(RealProcNameBox);
			Controls.Add(RealProcNameLabel);
			Controls.Add(FakeProcNameBox);
			Controls.Add(FakeProcNameLabel);
			Controls.Add(ModuleNameBox);
			Controls.Add(ModuleNameLabel);
			Controls.Add(ModuleDownloadBox);
			Controls.Add(ModuleUrlLabel);
			Controls.Add(VariantBox);
			Controls.Add(VariantLabel);
			Controls.Add(StartupModeLabel);
			Controls.Add(StartupModeCombo);
			Controls.Add(DirSearchButton);
			Controls.Add(ProjectDirBox);
			Controls.Add(ProjectDirLabel);
			Controls.Add(CompilerStatusLabel);
			Controls.Add(DebugModeToggle);
			Controls.Add(AntiKillToggle);
			Controls.Add(AutoStartToggle);
			Controls.Add(HideFolderToggle);
			Controls.Add(AntiTestModeToggle);
			Controls.Add(AntiVmToggle);
			Controls.Add(ConfigLabel);
			Controls.Add(CategoryIdBox);
			Controls.Add(CategoryIdLabel);
			Controls.Add(ServerIdBox);
			Controls.Add(ServerIdLabel);
			Controls.Add(textBox2);
			Controls.Add(BotTokenBox);
			Controls.Add(TokenLabel);
			Controls.Add(ClearButton);
			Controls.Add(BuildButton);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "BuilderUI";
			Text = "Hypothermia Builder";
			Load += GUI_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Button BuildButton;
		public Button ClearButton;
		public Label TokenLabel;
		public TextBox BotTokenBox;
		public TextBox textBox2;
		public TextBox ServerIdBox;
		public Label ServerIdLabel;
		public TextBox CategoryIdBox;
		public Label CategoryIdLabel;
		public Label ConfigLabel;
		public CheckBox AntiVmToggle;
		public CheckBox AntiTestModeToggle;
		public CheckBox AutoStartToggle;
		public CheckBox HideFolderToggle;
		public CheckBox AntiKillToggle;
		public CheckBox DebugModeToggle;
		public Label CompilerStatusLabel;
		public TextBox ProjectDirBox;
		public Label ProjectDirLabel;
		public Button DirSearchButton;
		public ComboBox StartupModeCombo;
		public Label StartupModeLabel;
		public TextBox VariantBox;
		public Label VariantLabel;
		public TextBox ModuleDownloadBox;
		public Label ModuleUrlLabel;
		public TextBox ModuleNameBox;
		public Label ModuleNameLabel;
		public TextBox StartupRegKeyNameBox;
		public Label StartupKeyNameLabel;
		public TextBox FolderNameBox;
		public Label FolderNameLabel;
		public TextBox RealProcNameBox;
		public Label RealProcNameLabel;
		public TextBox FakeProcNameBox;
		public Label FakeProcNameLabel;
		public CheckBox NoWindowToggle;
		public CheckBox TrimStringsToggle;
		public Label BuildOptionsLabel;
		public CheckBox CmdScriptToggle;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}
