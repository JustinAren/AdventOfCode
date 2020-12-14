using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day09 : Day
	{
		public override string Perform1(string inputString)
		{
			var inputArray = (ulong[]) this.ParseInput(inputString);
			var preamble = inputArray.Length > 25 ? 25 : 5;

			for (var i = preamble; i < inputArray.Length; i++)
			{
				var previousDigits = inputArray.Skip(i - preamble).Take(preamble).ToArray();
				if (!IsValid(inputArray[i], previousDigits)) return inputArray[i].ToString();
			}

			return null;
		}

		public override string Perform2(string inputString)
		{
			throw new NotImplementedException();
		}

		protected override object ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(UInt64.Parse).ToArray();
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
