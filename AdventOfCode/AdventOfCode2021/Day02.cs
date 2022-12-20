namespace AdventOfCode2021;

public class Day02 : Day<List<CommandDay02>>
{
    protected override List<CommandDay02> ParseInput(string inputString)
    {
        var result = new List<CommandDay02>();
        var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var splits = row.Split(' ');
            var command = (CommandEnum)Enum.Parse(typeof(CommandEnum), splits[0], true);
            var position = byte.Parse(splits[1]);
            result.Add(new CommandDay02(command, position));
        }

        return result;
    }

    public override string Perform1(string inputString)
    {
        var commands = ParseInput(inputString);
        var horizontal = 0;
        var depth = 0;

        foreach (var command in commands)
        {
            switch (command.CommandEnum)
            {
                case CommandEnum.Forward:
                    horizontal += command.Position;
                    break;
                case CommandEnum.Up:
                    depth -= command.Position;
                    break;
                case CommandEnum.Down:
                    depth += command.Position;
                    break;
            }
        }

        return (horizontal * depth).ToString();
    }

    public override string Perform2(string inputString)
    {
        var commands = ParseInput(inputString);
        var horizontal = 0;
        var depth = 0;
        var aim = 0;

        foreach (var command in commands)
        {
            switch (command.CommandEnum)
            {
                case CommandEnum.Forward:
                    horizontal += command.Position;
                    depth += aim * command.Position;
                    break;
                case CommandEnum.Up:
                    aim -= command.Position;
                    break;
                case CommandEnum.Down:
                    aim += command.Position;
                    break;
            }
        }

        return (horizontal * depth).ToString();
    }
}

public enum CommandEnum : byte
{
    Forward,
    Up,
    Down,
}

public readonly record struct CommandDay02(CommandEnum CommandEnum, byte Position);