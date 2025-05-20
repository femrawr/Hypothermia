using builder.Source;
using builder.Source.Main;

namespace builder
{
	public partial class BuilderUI : Form
	{
		public BuilderUI()
		{
			InitializeComponent();
		}

		private void GUI_Load(object sender, EventArgs e)
		{
			this.MaximizeBox = false;
			this.Clear_Clicked(sender, e);
		}

		private void SearchDir_Clicked(object sender, EventArgs e)
		{
			using var browser = new FolderBrowserDialog();
			browser.ShowNewFolderButton = false;

			if (browser.ShowDialog() == DialogResult.OK)
			{
				this.ProjectDirBox.Text = browser.SelectedPath;
			}
		}

		private void Build_Clicked(object sender, EventArgs e)
		{
			Builder.Compile(this);
		}

		private void StarupMode_Changed(object sender, EventArgs e)
		{
			var item = this.StartupModeCombo.SelectedItem;
			if (item != null && item.ToString() == "Run module")
			{
				this.ModuleUrlLabel.Visible = true;
				this.ModuleUrlLabel.Enabled = true;
				this.ModuleDownloadBox.Visible = true;
				this.ModuleDownloadBox.Enabled = true;

				this.ModuleNameLabel.Visible = true;
				this.ModuleNameLabel.Enabled = true;
				this.ModuleNameBox.Visible = true;
				this.ModuleNameBox.Enabled = true;

				return;
			}

			this.ModuleUrlLabel.Visible = false;
			this.ModuleUrlLabel.Enabled = false;
			this.ModuleDownloadBox.Visible = false;
			this.ModuleDownloadBox.Enabled = false;

			this.ModuleNameLabel.Visible = false;
			this.ModuleNameLabel.Enabled = false;
			this.ModuleNameBox.Visible = false;
			this.ModuleNameBox.Enabled = false;
		}

		private void Clear_Clicked(object sender, EventArgs e)
		{
			foreach (Control control in this.Controls)
			{
				switch (control)
				{
					case TextBox textBox:
						textBox.Clear();
						break;

					case CheckBox checkBox:
						checkBox.Checked = true;
						break;

					case ComboBox comboBox:
						comboBox.SelectedIndex = 0;
						break;
				}
			}

			this.DebugModeToggle.Checked = false;
			this.CmdScriptToggle.Checked = false;

			this.ModuleUrlLabel.Visible = false;
			this.ModuleUrlLabel.Enabled = false;
			this.ModuleDownloadBox.Visible = false;
			this.ModuleDownloadBox.Enabled = false;

			this.ModuleNameLabel.Visible = false;
			this.ModuleNameLabel.Enabled = false;
			this.ModuleNameBox.Visible = false;
			this.ModuleNameBox.Enabled = false;

			this.ProjectDirBox.Text = Program.GetProjectBase();
		}
	}
}
