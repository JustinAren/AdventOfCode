using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day09 : Day<ulong[]>
	{
		public override ulong Perform1(string inputString)
		{
			var inputArray = this.ParseInput(inputString);
			return GetInvalidEntry(inputArray);
		}

		public override ulong Perform2(string inputString)
		{
			var inputArray = this.ParseInput(inputString);
			var invalidValue = GetInvalidEntry(inputArray);

			for (var i = 0; i < inputArray.Length; i++)
			{
				for (var j = i + 1; j < inputArray.Length; j++)
				{
					if (i == j) continue;
					var numbers = inputArray.Skip(i).Take(j - i).ToArray();
					if ((ulong) numbers.Sum(n => (long) n) == invalidValue) return numbers.Min() + numbers.Max();
				}
			}

			return 0;
		}

		protected override ulong[] ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(UInt64.Parse).ToArray();
		}

		private static ulong GetInvalidEntry(IReadOnlyList<ulong> inputArray)
		{
			var preamble = inputArray.Count > 25 ? 25 : 5;

			for (var i = preamble; i < inputArray.Count; i++)
			{
				var previousDigits = inputArray.Skip(i - preamble).Take(preamble).ToArray();
				if (!IsValid(inputArray[i], previousDigits)) return inputArray[i];
			}

			return 0;
		}

		private static bool IsValid(ulong controlDigit, IReadOnlyList<ulong> previousDigits)
		{
			for (var i = 0; i < previousDigits.Count; i++)
			{
				for (var j = i + 1; j < previousDigits.Count; j++)
				{
					if (previousDigits[i] + previousDigits[j] == controlDigit) return true;
				}
			}

			return false;
		}
	}
}
