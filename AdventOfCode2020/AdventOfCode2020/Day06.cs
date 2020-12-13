using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day06 : Day
	{
		public override string Perform1(string inputString)
		{
			var inputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			return inputStrings.Select(ParseInput).Sum(d => d.Count).ToString();
		}

		public override string Perform2(string inputString)
		{
			throw new NotImplementedException();
		}

		private static Dictionary<char, int> ParseInput(string inputString)
		{
			var resultDictionary = new Dictionary<char, int>();

			var inputs = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			foreach (var input in inputs)
			{
				foreach (var character in input)
				{
					if (resultDictionary.ContainsKey(character)) resultDictionary[character]++;
					else resultDictionary.Add(character, 1);
				}
			}

			return resultDictionary;
		}
	}
}
