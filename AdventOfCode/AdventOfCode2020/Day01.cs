using AdventOfCodeBase;
using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day01 : Day<int[]>
	{
		public override ulong Perform1(string inputString)
		{
			var intArray = this.ParseInput(inputString);
			var result = 0;
			foreach (var a in intArray)
			{
				foreach (var b in intArray)
				{
					if (a == b) continue;
					if (a + b != 2020) continue;
					result = a * b;
					break;
				}
				if (result != 0) break;
			}
			return (ulong) result;
		}

		public override ulong Perform2(string inputString)
		{
			var intArray = this.ParseInput(inputString);
			var result = 0;
			foreach (var a in intArray)
			{
				foreach (var b in intArray)
				{
					foreach (var c in intArray)
					{
						if (a == b || b == c || a == c) continue;
						if (a + b + c != 2020) continue;
						result = a * b * c;
						break;
					}
					if (result != 0) break;
				}
				if (result != 0) break;
			}
			return (ulong) result;
		}

		protected override int[] ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
		}
	}
}
