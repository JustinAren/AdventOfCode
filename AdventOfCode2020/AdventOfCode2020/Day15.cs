using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day15 : Day<ulong[]>
	{
		public override ulong Perform1(string inputString)
		{
			return this.SolveProblem(inputString, 2020);
		}

		public override ulong Perform2(string inputString)
		{
			return this.SolveProblem(inputString, 30000000);
		}

		private ulong SolveProblem(string inputString, ulong iterations)
		{
			var inputArray = this.ParseInput(inputString);
			var resultDictionary = new Dictionary<ulong, List<ulong>>();
			ulong lastNumber = 0;

			for (ulong i = 1; i <= iterations; i++)
			{
				if (i - 1 < (ulong) inputArray.Length)
				{
					resultDictionary.Add(inputArray[i - 1], new List<ulong>{i});
					lastNumber = inputArray[i - 1];
					continue;
				}

				if (resultDictionary.ContainsKey(lastNumber))
				{
					resultDictionary[lastNumber].Add(i - 1);
					var listLength = resultDictionary[lastNumber].Count;
					lastNumber = resultDictionary[lastNumber][listLength-1] - resultDictionary[lastNumber][listLength-2];
				}
				else
				{
					resultDictionary.Add(lastNumber, new List<ulong>{i - 1});
					lastNumber = 0;
				}
			}

			return lastNumber;
		}

		protected override ulong[] ParseInput(string inputString)
		{
			return inputString.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(UInt64.Parse).ToArray();
		}
	}
}
