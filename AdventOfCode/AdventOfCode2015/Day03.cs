using System.Collections.Generic;
using AdventOfCodeBase;

namespace AdventOfCode2015
{
	public class Day03 : Day<string>
	{
		public override long Perform1(string inputString)
		{
			var input = this.ParseInput(inputString);
			var resultDictionary = PerformOperations(input);
			return resultDictionary.Count;
		}

		public override long Perform2(string inputString)
		{
			var input = this.ParseInput(inputString);
			throw new System.NotImplementedException();
		}

		private static Dictionary<(int X, int Y), int> PerformOperations(string operations)
		{
			(int X, int Y) currentPosition = (0, 0);
			var resultDictionary = new Dictionary<(int X, int Y), int>() { {currentPosition, 1} };
			foreach (var operation in operations)
			{
				switch (operation)
				{
					case '^': currentPosition.Y--; break;
					case '>': currentPosition.X++; break;
					case 'v': currentPosition.Y++; break;
					case '<': currentPosition.X--; break;
				}

				if (resultDictionary.ContainsKey(currentPosition)) resultDictionary[currentPosition]++;
				else resultDictionary.Add(currentPosition, 1);
			}
			return resultDictionary;
		}

		protected override string ParseInput(string inputString)
		{
			return inputString;
		}
	}
}
