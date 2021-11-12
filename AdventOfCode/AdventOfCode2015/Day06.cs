namespace AdventOfCode2015;

public class Day06 : Day<List<CommandStruct>>
{
	public override long Perform1(string inputString)
	{
		var commands = this.ParseInput(inputString);
		var grid = new bool[1000, 1000];
		foreach (var (commandEnum, (startX, startY), (endX, endY)) in commands)
		{
			for (var i = startX; i <= endX; i++)
			{
				for (var j = startY; j <= endY; j++)
				{
					grid[i, j] = commandEnum switch
					{
						CommandEnum.Toggle => !grid[i, j],
						CommandEnum.TurnOn => true,
						CommandEnum.TurnOff => false,
						_ => throw new ArgumentOutOfRangeException(),
					};
				}
			}
		}

		var count = 0L;

		for (var i = 0; i < 1000; i++) 
		for (var j = 0; j < 1000; j++) 
			if (grid[i, j]) count++;

		return count;
	}

	public override long Perform2(string inputString)
	{
		var commands = this.ParseInput(inputString);
		throw new NotImplementedException();
	}

	protected override List<CommandStruct> ParseInput(string inputString)
	{
		var result = new List<CommandStruct>();
		var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		foreach (var row in rows)
		{
			var words = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			if (words[0] == "toggle") result.Add(CreateCommand(CommandEnum.Toggle, words[1], words[3]));
			else switch (words[1])
			{
				case "on": result.Add(CreateCommand(CommandEnum.TurnOn, words[2], words[4])); break;
				case "off":result.Add(CreateCommand(CommandEnum.TurnOff, words[2], words[4])); break;
			}
		}

		return result;

		static CommandStruct CreateCommand(CommandEnum command, string startCoordinatesString, string endCoordinatesString)
		{
			var startCoordinates = startCoordinatesString.Split(",", StringSplitOptions.RemoveEmptyEntries);
			var endCoordinates = endCoordinatesString.Split(",", StringSplitOptions.RemoveEmptyEntries);
			return new CommandStruct(command, (Int32.Parse(startCoordinates[0]), Int32.Parse(startCoordinates[1])), (Int32.Parse(endCoordinates[0]), Int32.Parse(endCoordinates[1])));
		}
	}
}

public readonly record struct CommandStruct(CommandEnum Command, (int X, int Y) Start, (int X, int Y) End);

public enum CommandEnum : byte
{
	Toggle,
	TurnOn,
	TurnOff,
}
