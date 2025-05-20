namespace builder.Source
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new BuilderUI());
		}

		public static string? GetProjectBase()
		{
			string dir = Directory.GetCurrentDirectory();

			var dirInfo = new DirectoryInfo(dir);
			while (dirInfo != null && dirInfo.Name != "Hypothermia")
				dirInfo = dirInfo.Parent;

			if (dir == null)
				return "";

			return dirInfo?.FullName;
		}
	}
}