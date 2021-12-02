namespace AdventOfCode2021;

public class Day02 : Day<List<CommandDay02>>
{
	public override long Perform1(string inputString)
	{
		var commands = this.ParseInput(inputString);
		var horizontal = 0;
		var vertical = 0;

		foreach (var command in commands)
		{
			switch (command.CommandEnum)
			{
				case CommandEnum.Forward: horizontal += command.Position; break;
				case CommandEnum.Up: vertical -= command.Position; break;
				case CommandEnum.Down: vertical += command.Position; break;
			}
		}

		return horizontal * vertical;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override List<CommandDay02> ParseInput(string inputString)
	{
		var result = new List<CommandDay02>();
		var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		foreach (var row in rows)
		{
			var splits = row.Split(' ');
			var command = (CommandEnum)Enum.Parse(typeof(CommandEnum), splits[0], ignoreCase: true);
			var position = Byte.Parse(splits[1]);
			result.Add(new CommandDay02(command, position));
		}
		return result;
	}
}

public enum CommandEnum : byte
{
	Forward,
	Up,
	Down,
}

public readonly record struct CommandDay02(CommandEnum CommandEnum, byte Position);
