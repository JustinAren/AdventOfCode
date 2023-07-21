namespace AdventOfCode2021;

public class Day02 : Day<List<CommandDay02>>
{
    protected override List<CommandDay02> ParseInput(string inputString)
    {
        var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        return (from row in rows
                select row.Split(' ')
                into splits
                let command = (Command)Enum.Parse(typeof(Command), splits[0], true)
                let position = byte.Parse(splits[1])
                select new CommandDay02(command, position)).ToList();
    }

    public override string Perform1(string inputString)
    {
        var commands = ParseInput(inputString);
        var horizontal = 0;
        var depth = 0;

        foreach (var command in commands)
            switch (command.Command)
            {
                case Command.Forward:
                    horizontal += command.Position;
                    break;

                case Command.Up:
                    depth -= command.Position;
                    break;

                case Command.Down:
                    depth += command.Position;
                    break;
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
            switch (command.Command)
            {
                case Command.Forward:
                    horizontal += command.Position;
                    depth += aim * command.Position;
                    break;

                case Command.Up:
                    aim -= command.Position;
                    break;

                case Command.Down:
                    aim += command.Position;
                    break;
            }

        return (horizontal * depth).ToString();
    }
}

public enum Command : byte
{
    Forward,
    Up,
    Down
}

public readonly record struct CommandDay02(Command Command, byte Position);