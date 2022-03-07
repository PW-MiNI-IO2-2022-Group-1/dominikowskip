using System;

namespace TDD_IO2
{
	public class StringCalculator
	{
		private static readonly string[] delimeters = { ",", "\n" };

		public static int Calculate(String s)
		{
			if (String.IsNullOrWhiteSpace(s))
				return 0;

			string[] localDelimeters = delimeters;
			if (s.Length >= 3 && s.Substring(0, 2) == "//")
            {
				string[] str = s.Split("\n", 2);
				s = str[1];

				string delimeter;
				if (str[0][2] == '[' && str[0][str[0].Length-1] == ']')
				{
					delimeter = str[0].Substring(3, str[0].Length - 4);
				}
				else delimeter = str[0][2].ToString();
				localDelimeters = localDelimeters.Append(delimeter).ToArray();
            }

			int[] numbers = s.Split(localDelimeters, StringSplitOptions.None).Select(str => Int32.Parse(str)).ToArray();

			int result = 0;
			foreach(int num in numbers)
            {
				if (num < 0) throw new ArgumentException("Negative argument");
				if (num > 1000) continue;
				result += num;
            }

			return result;
		}
	}
}

