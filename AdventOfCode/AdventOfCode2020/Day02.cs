using System;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day02 : Day<string[]>
	{
		public override ulong Perform1(string inputString)
		{
			var count = 0;
			var inputArray = this.ParseInput(inputString);

			foreach (var line in inputArray)
			{
				var lineSplitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var limits = lineSplitted[0].Split('-', StringSplitOptions.RemoveEmptyEntries);
				var lowerLimit = Int32.Parse(limits[0]);
				var upperLimit = Int32.Parse(limits[1]);
				var matchingCharacter = lineSplitted[1][0];
				var occurrences = lineSplitted[2].Count(c => c == matchingCharacter);
				if (occurrences >= lowerLimit && occurrences <= upperLimit) count++;
			}

			return (ulong) count;
		}

		public override ulong Perform2(string inputString)
		{
			var count = 0;
			var inputArray = this.ParseInput(inputString);

			foreach (var line in inputArray)
			{
				var lineSplitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var positions = lineSplitted[0].Split('-', StringSplitOptions.RemoveEmptyEntries);
				var firstPosition = Int32.Parse(positions[0]);
				var secondPosition = Int32.Parse(positions[1]);
				var matchingCharacter = lineSplitted[1][0];
				var firstCharacter = lineSplitted[2][firstPosition - 1];
				var secondCharacter = lineSplitted[2][secondPosition - 1];
				if (firstCharacter == matchingCharacter && secondCharacter != matchingCharacter ||
				    firstCharacter != matchingCharacter && secondCharacter == matchingCharacter) count++;
			}

			return (ulong) count;
		}

		protected override string[] ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
