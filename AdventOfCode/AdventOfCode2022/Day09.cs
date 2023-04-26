namespace AdventOfCode2022;

public class Day09 : Day<Rope>
{
    protected override Rope ParseInput(string inputString)
    {
        return Rope.Parse(inputString);
    }

    public override string Perform1(string inputString)
    {
        var rope = ParseInput(inputString);
        rope.ProcessInstructions();
        return rope.Visited.Count.ToString();
    }

    public override string Perform2(string inputString)
    {
        var rope = ParseInput(inputString);
        throw new NotImplementedException();
    }
}

public class Rope
{
    public Rope(IReadOnlyList<(char Direction, int Count)> instructions)
    {
        Instructions = instructions;
    }

    public static Rope Parse(string input)
    {
        var instructions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(row => (row[0], int.Parse(row[1..])))
            .ToList();

        return new Rope(instructions);
    }

    private void ProcessInstruction(char direction, int count)
    {
        var (x, y) = Head;
        var (a, b) = Tail;
        var (dx, dy) = direction switch
        {
            'U' => (0, 1),
            'D' => (0, -1),
            'L' => (-1, 0),
            'R' => (1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        for (var i = 0; i < count; i++)
        {
            x += dx;
            y += dy;

            if (Math.Abs(x - a) > 1)
            {
                a += dx;
                if (Math.Abs(y - b) > 0) b += direction == 'R' ? 1 : -1;
            }

            if (Math.Abs(y - b) > 1)
            {
                b += dy;
                if (Math.Abs(x - a) > 0) a += direction == 'U' ? 1 : -1;
            }

            Visited.Add((a, b));
        }

        Head = (x, y);
        Tail = (a, b);
    }

    public void ProcessInstructions()
    {
        foreach (var (direction, count) in Instructions)
            ProcessInstruction(direction, count);
    }

    public (int X, int Y) Head { get; private set; } = (0, 0);

    public IReadOnlyList<(char Direction, int Count)> Instructions { get; }

    public (int X, int Y) Tail { get; private set; } = (0, 0);

    public HashSet<(int X, int Y)> Visited { get; } = new() { (0, 0) };
}