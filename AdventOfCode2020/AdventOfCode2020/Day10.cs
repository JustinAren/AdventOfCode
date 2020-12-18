using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day10 : Day<List<int>>
	{
		public override ulong Perform1(string inputString)
		{
			var inputList = this.ParseInput(inputString);

			var resultDictionary = new Dictionary<int, int>
			{
				{ 1, 0 },
				{ 2, 0 },
				{ 3, 0 },
			};

			for (var i = 1; i < inputList.Count; i++) resultDictionary[inputList[i] - inputList[i - 1]]++;

			return (ulong)(resultDictionary[1] * resultDictionary[3]);
		}

		public override ulong Perform2(string inputString)
		{
			var inputList = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override List<int> ParseInput(string inputString)
		{
			var inputList = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).OrderBy(i => i).ToList();
			var maxValue = inputList.Last() + 3;
			inputList.Insert(0, 0);
			inputList.Add(maxValue);
			return inputList;
		}
	}
}
