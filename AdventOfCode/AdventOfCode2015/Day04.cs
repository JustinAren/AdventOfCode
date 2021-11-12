using System;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeBase;

namespace AdventOfCode2015
{
	public class Day04 : Day<string>
	{
		public override long Perform1(string inputString)
		{
			var secretKey = this.ParseInput(inputString);

			var counter = 0L;

			while (true)
			{
				counter++;
				var md5 = GenerateMd5($"{secretKey}{counter}");
				if (md5.StartsWith("00000")) return counter;
			}
		}

		public override long Perform2(string inputString)
		{
			var secretKey = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override string ParseInput(string inputString)
		{
			return inputString;
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
