using System;

namespace AdventOfCode2020
{
	public class Day03 : Day
	{
		public override string Perform1(string inputString)
		{
			var treeCount = 0;
			var inputArray = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var position = 0;
			var lineLength = inputArray[0].Length;

			foreach (var line in inputArray)
			{
				position %= lineLength;
				if (line[position] == '#') treeCount++;
				position += 3;
			}

			return treeCount.ToString();
		}

		public override string Perform2(string inputString)
		{
			var treeCount = 0;
			var inputArray = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);



			return treeCount.ToString();
		}
	}
}
