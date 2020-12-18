using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day03 : Day<string[]>
	{
		public override ulong Perform1(string inputString)
		{
			var inputArray = this.ParseInput(inputString);
			return CountTrees(inputArray, 1, 3);
		}

		public override ulong Perform2(string inputString)
		{
			var inputArray = this.ParseInput(inputString);
			var solutions = new[]
			{
				CountTrees(inputArray, 1, 1),
				CountTrees(inputArray, 1, 3),
				CountTrees(inputArray, 1, 5),
				CountTrees(inputArray, 1, 7),
				CountTrees(inputArray, 2, 1),
			};
			return solutions.Aggregate((ulong) 1, (a, b) => a * b);
		}

		protected override string[] ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		}

		private static ulong CountTrees(string[] inputArray, int down, int right)
		{
			ulong treeCount = 0;
			var position = 0;
			var lineLength = inputArray[0].Length;

			for (var index = 0; index < inputArray.Length; index += down)
			{
				var line = inputArray[index];
				position %= lineLength;
				if (line[position] == '#') treeCount++;
				position += right;
			}

			return treeCount;
		}
	}
}
