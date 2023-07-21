namespace AdventOfCode2020;

public class Day08 : Day<(Operation Operation, int Argument)[]>
{
    private static (bool InfiniteLoop, int AccumulatorResult) Execute(
        IReadOnlyList<(Operation Operation, int Argument)> commands)
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

    private static (Operation Operation, int Argument) ParseCommand(string command)
    {
        var operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var operation = operations[0] switch
        {
            "acc" => Operation.Accumulator,
            "jmp" => Operation.Jump,
            _ => Operation.NoOperation
        };

        var argument = int.Parse(operations[1]);
        return (operation, argument);
    }

    protected override (Operation Operation, int Argument)[] ParseInput(string inputString)
    {
        var commands = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        return commands.Select(ParseCommand).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var commands = ParseInput(inputString);
        return Execute(commands).AccumulatorResult.ToString();
    }

    public override string Perform2(string inputString)
    {
        var commands = ParseInput(inputString);
        var commandsCopy = new (Operation Operation, int Argument)[commands.Length];

        for (var i = 0; i < commands.Length; i++)
        {
            var (operation, argument) = commands[i];
            if (operation == Operation.Accumulator) continue;
            var newCommand = (operation == Operation.Jump ? Operation.NoOperation : Operation.Jump, argument);
            commands.CopyTo(commandsCopy, 0);
            commandsCopy[i] = newCommand;
            var (infiniteLoop, accumulatorResult) = Execute(commandsCopy);
            if (!infiniteLoop) return accumulatorResult.ToString();
        }

        return 0.ToString();
    }
}

public enum Operation
{
    NoOperation,
    Accumulator,
    Jump
}