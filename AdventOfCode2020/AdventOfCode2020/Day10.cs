using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day10 : Day
	{
		public override ulong Perform1(string inputString)
		{
			var inputArray = (int[])this.ParseInput(inputString);

			var resultDictionary = new Dictionary<int, int>()
			{
				{ 1, 0 },
				{ 2, 0 },
				{ 3, 1 },
			};

			for (var i = 0; i < inputArray.Length; i++)
			{
				if (i == 0) resultDictionary[inputArray[0]]++;
				else resultDictionary[inputArray[i] - inputArray[i - 1]]++;
			}

			return (ulong)(resultDictionary[1] * resultDictionary[3]);
		}

		public override ulong Perform2(string inputString)
		{
			var inputArray = (int[])this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override object ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).OrderBy(i => i).ToArray();
		}
	}
}
