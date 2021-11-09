using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day15 : Day<long[]>
	{
		public override long Perform1(string inputString)
		{
			return this.SolveProblem(inputString, 2020);
		}

		public override long Perform2(string inputString)
		{
			return this.SolveProblem(inputString, 30000000);
		}

		private long SolveProblem(string inputString, long iterations)
		{
			var inputArray = this.ParseInput(inputString);
			var resultDictionary = new Dictionary<long, List<long>>();
			long lastNumber = 0;

			for (long i = 1; i <= iterations; i++)
			{
				if (i - 1 < inputArray.Length)
				{
					resultDictionary.Add(inputArray[i - 1], new List<long>{i});
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
					resultDictionary.Add(lastNumber, new List<long>{i - 1});
					lastNumber = 0;
				}
			}

			return lastNumber;
		}

		protected override long[] ParseInput(string inputString)
		{
			return inputString.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int64.Parse).ToArray();
		}
	}
}
