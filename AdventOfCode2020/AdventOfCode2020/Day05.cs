﻿using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day05 : Day
	{
		private static readonly int[] Rows = Enumerable.Range(0, 128).ToArray();
		private static readonly int[] Columns = Enumerable.Range(0, 8).ToArray();

		public override string Perform1(string inputString)
		{
			var inputArray = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			return inputArray.Select(CalculateSeatId).Max().ToString();
		}

		public override string Perform2(string inputString)
		{
			var inputArray = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			throw new NotImplementedException();
		}

		public static int CalculateSeatId(string inputString)
		{
			var (row, column) = ParseString(inputString);
			return row * 8 + column;
		}

		private static (int Row, int Column) ParseString(string inputString)
		{
			var rows = Rows;
			var columns = Columns;

			foreach (var character in inputString)
			{
				switch (character)
				{
					case 'F':
					case 'B':
						rows = ParseCharacter(rows, character);
						break;
					case 'L':
					case 'R':
						columns = ParseCharacter(columns, character);
						break;
				}
			}

			return (rows.Single(), columns.Single());
		}

		private static int[] ParseCharacter(int[] inputArray, char character)
		{
			switch (character)
			{
				case 'F':
				case 'L':
					return GetHalfOfArray(inputArray, getLowerHalf: true);
				case 'B':
				case 'R':
					return GetHalfOfArray(inputArray, getLowerHalf: false);
			}

			return inputArray;
		}

		private static int[] GetHalfOfArray(int[] inputArray, bool getLowerHalf)
		{
			var half = inputArray.Length / 2;
			return (getLowerHalf ? inputArray.Take(half) : inputArray.TakeLast(half)).ToArray();
		}
	}
}