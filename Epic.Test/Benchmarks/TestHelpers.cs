using System;
using System.Text;

namespace Epic.Test.Benchmarks
{
	public class TestHelpers
	{
		private static readonly Random random = new Random((int)DateTime.Now.Ticks);

		public static char RandomChar()
		{
			return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
		}

		public static string RandomString(int length)
		{
			var builder = new StringBuilder();
			
			for (int i = 0; i < length; i++)
				builder.Append(RandomChar());

			return builder.ToString();
		}

		public static string RandomStringRandomLength(int minLength, int maxLength)
		{
			var length = random.Next(minLength, maxLength);
			return RandomString(length);
		}

		public static string RandomCapitalizedString(int minLength, int maxLength)
		{
			return Char.ToUpper(RandomChar()) + RandomStringRandomLength(minLength - 1, maxLength - 1);
		}

		public static string RandomFullName()
		{
			return RandomCapitalizedString(5, 12) + " " + RandomCapitalizedString(5, 12);
		}

		public static decimal RandomPrice()
		{
			return random.Next(10000) / 100m;
		}
	}
}
