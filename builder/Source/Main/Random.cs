using System.Text;

namespace builder.Source.Main
{
	public class Random
	{
		private static readonly DateTimeOffset discordStart = new(2015, 1, 1, 0, 0, 0, TimeSpan.Zero);
		private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		public static string GenId()
		{
			long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			long start = now - discordStart.ToUnixTimeMilliseconds();

			long worker = new System.Random().Next(0, 31);
			long process = new System.Random().Next(0, 31);
			long increment = new System.Random().Next(0, 4095);

			return ((start << 22) | (worker << 17) | (process << 12) | increment).ToString();
		}

		public static string GenToken()
		{
			string p1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(GenId())).TrimEnd('=');

			return p1 + "." + GenString(6) + "." + GenString(34);
		}

        public static string GenString(int len)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < len; i++)
			{
				builder.Append(chars[new System.Random().Next(chars.Length)]);
			}

			return builder.ToString();
		}
	}
}
