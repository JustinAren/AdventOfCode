using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day08 : Day<(Operation Operation, int Argument)[]>
	{
		public override long Perform1(string inputString)
		{
			var commands = this.ParseInput(inputString);
			return Execute(commands).AccumulatorResult;
		}

		public override long Perform2(string inputString)
		{
			var commands = this.ParseInput(inputString);
			var commandsCopy = new (Operation Operation, int Argument)[commands.Length];

			for (var i = 0; i < commands.Length; i++)
			{
				var (operation, argument) = commands[i];
				if (operation == Operation.Accumulator) continue;
				var newCommand = (operation == Operation.Jump ? Operation.NoOperation : Operation.Jump, argument);
				commands.CopyTo(commandsCopy, 0);
				commandsCopy[i] = newCommand;
				var (infiniteLoop, accumulatorResult) = Execute(commandsCopy);
				if (!infiniteLoop) return accumulatorResult;
			}

			return 0;
		}

		private static (bool InfiniteLoop, int AccumulatorResult) Execute(IReadOnlyList<(Operation Operation, int Argument)> commands)
		{
			var seenList = new List<int>();
			var accumulatorResult = 0;

			for (var i = 0; i < commands.Count; i++)
			{
				if (seenList.Contains(i)) return (true, accumulatorResult);

				seenList.Add(i);
				var (operation, argument) = commands[i];

				switch (operation)
				{
					case Operation.Accumulator:
						accumulatorResult += argument;
						break;
					case Operation.Jump:
						i += argument - 1;
						break;
				}
			}

			return (false, accumulatorResult);
		}

		protected override (Operation Operation, int Argument)[] ParseInput(string inputString)
		{
			var commands = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			return commands.Select(ParseCommand).ToArray();
		}

		private static (Operation Operation, int Argument) ParseCommand(string command)
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
