using System.Text;
using AdventOfCodeBase;

namespace AdventOfCode2015
{
	public class Day04 : Day<string>
	{
		public override long Perform1(string inputString)
		{
			var secretKey = this.ParseInput(inputString);
			return Perform(5, secretKey);
		}

		public override long Perform2(string inputString)
		{
			var secretKey = this.ParseInput(inputString);
			return Perform(6, secretKey);
		}

		protected override string ParseInput(string inputString)
		{
			return inputString;
		}

		private static long Perform(byte leadingZeroes, string secretKey)
		{
			var counter = 0L;
			var prefix = new string('0', leadingZeroes);

			while (true)
			{
				counter++;
				var md5 = GenerateMd5($"{secretKey}{counter}");
				if (md5.StartsWith(prefix)) return counter;
			}
		}

		private static string GenerateMd5(string input)
		{
			// Use input string to calculate MD5 hash
			using var md5 = System.Security.Cryptography.MD5.Create();
			var inputBytes = Encoding.UTF8.GetBytes(input);
			var hashBytes = md5.ComputeHash(inputBytes);

			// Convert the byte array to hexadecimal string
			var sb = new StringBuilder();
			foreach (var b in hashBytes) sb.Append(b.ToString("X2"));
			return sb.ToString();
		}
	}
}
