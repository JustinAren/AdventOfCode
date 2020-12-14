using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day06 : Day
	{
		public override ulong Perform1(string inputString)
		{
			var inputStrings = (string[]) this.ParseInput(inputString);
			return (ulong) inputStrings.Select(ParseInput1).Sum();
		}

		public override ulong Perform2(string inputString)
		{
			var inputStrings = (string[]) this.ParseInput(inputString);
			return (ulong) inputStrings.Select(ParseInput2).Sum();
		}

		protected override object ParseInput(string inputString)
		{
			return inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
		}

		private static int ParseInput1(string inputString)
		{
			var result = new HashSet<char>();

			var inputs = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

			foreach (var input in inputs)
				foreach (var character in input) result.Add(character);

			return result.Count;
		}

		private static int ParseInput2(string inputString)
		{
			var inputs = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var dictionary = new Dictionary<char, int>();

			foreach (var input in inputs)
				foreach (var character in input)
				{
					if (dictionary.ContainsKey(character)) dictionary[character]++;
					else dictionary.Add(character, 1);
				}

			return dictionary.Count(kvp => kvp.Value == inputs.Length);
		}
	}
}
