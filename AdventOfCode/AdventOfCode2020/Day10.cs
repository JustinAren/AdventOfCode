using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day10 : Day<List<int>>
	{
		public override ulong Perform1(string inputString)
		{
			var inputList = this.ParseInput(inputString);
			var maxValue = inputList.Last() + 3;
			inputList.Insert(0, 0);
			inputList.Add(maxValue);

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
			return (ulong) this.Combinations(0, inputList);
		}

		private readonly Dictionary<int, long> _values = new();
		
		private long Combinations(int curValue, IEnumerable<int> input)
		{
			if (!input.Any()) return 1;
			if (this._values.ContainsKey(curValue)) return this._values[curValue];
			this._values[curValue] = input.TakeWhile(x => x > curValue && x <= curValue + 3).Select((x, idx) => this.Combinations(x, input.Skip(idx + 1))).Sum();
			return this._values[curValue];
		}

		protected override List<int> ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).OrderBy(i => i).ToList();
		}
	}
}
