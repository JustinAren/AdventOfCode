using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day08 : Day
	{
		public override string Perform1(string inputString)
		{
			var commands = ParseInput(inputString).ToArray();

			var seenList = new List<int>();
			var accumulator = 0;

			for (var i = 0; i < commands.Length; i++)
			{
				if (seenList.Contains(i)) break;

				seenList.Add(i);
				var (operation, argument) = commands[i];

				switch (operation)
				{
					case Operation.Accumulator:
						accumulator += argument;
						break;
					case Operation.Jump:
						i += argument - 1;
						break;
				}
			}

			return accumulator.ToString();
		}

		public override string Perform2(string inputString)
		{
			throw new NotImplementedException();
		}

		private static IEnumerable<(Operation, int)> ParseInput(string inputString)
		{
			var commands = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			return commands.Select(ParseCommand);
		}

		private static (Operation, int) ParseCommand(string command)
		{
			var operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			var operation = operations[0] switch
			{
				"acc" => Operation.Accumulator,
				"jmp" => Operation.Jump,
				_ => Operation.NoOperation,
			};

			var argument = Int32.Parse(operations[1]);
			return (operation, argument);
		}
	}

	public enum Operation
	{
		NoOperation,
		Accumulator,
		Jump,
	}
}
