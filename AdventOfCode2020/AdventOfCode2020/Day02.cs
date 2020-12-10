﻿using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day02 : Day
	{
		public override string Perform1(string inputString)
		{
			var count = 0;
			var inputArray = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

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

			return count.ToString();
		}

		public override string Perform2(string inputString)
		{
			throw new NotImplementedException();
		}
	}
}