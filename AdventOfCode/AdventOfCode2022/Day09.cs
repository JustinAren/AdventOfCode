namespace AdventOfCode2022;

public class Day09 : Day<Rope>
{
    protected override Rope ParseInput(string inputString) => Rope.Parse(inputString);

    public override string Perform1(string inputString)
    {
        var rope = ParseInput(inputString);
        rope.SetKnots(2);
        rope.ProcessInstructions();
        return rope.TailVisited.Count.ToString();
    }

    public override string Perform2(string inputString)
    {
        var rope = ParseInput(inputString);
        rope.SetKnots(10);
        rope.ProcessInstructions();
        return rope.TailVisited.Count.ToString();
    }
}

public class Rope
{
    public Rope(IReadOnlyList<(char Direction, int Count)> instructions) => Instructions = instructions;

    public static Rope Parse(string input)
    {
        var instructions = input.Split(Environment.NewLine,
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(row => (row[0], int.Parse(row[1..])))
            .ToList();

        return new Rope(instructions);
    }

    private void ProcessInstruction(char direction, int count)
    {
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
            Knots[0].X += dx;
            Knots[0].Y += dy;

            for (var j = 1; j < Knots.Length; j++)
            {
                if (Math.Abs(Knots[j - 1].X - Knots[j].X) == 2 &&
                    Math.Abs(Knots[j - 1].Y - Knots[j].Y) == 2)
                {
                    Knots[j].X = Knots[j - 1].X - Knots[j].X > 0 ? Knots[j - 1].X - 1 : Knots[j - 1].X + 1;
                    Knots[j].Y = Knots[j - 1].Y - Knots[j].Y > 0 ? Knots[j - 1].Y - 1 : Knots[j - 1].Y + 1;
                }

                if (Math.Abs(Knots[j - 1].X - Knots[j].X) > 1)
                {
                    Knots[j].X = Knots[j - 1].X - Knots[j].X > 0 ? Knots[j - 1].X - 1 : Knots[0].X + 1;
                    Knots[j].Y = Knots[j - 1].Y;
                }

                if (Math.Abs(Knots[j - 1].Y - Knots[j].Y) > 1)
                {
                    Knots[j].X = Knots[j - 1].X;
                    Knots[j].Y = Knots[j - 1].Y - Knots[j].Y > 0 ? Knots[j - 1].Y - 1 : Knots[0].Y + 1;
                }
            }

            TailVisited.Add(Knots[^1]);
        }
    }

    public void ProcessInstructions()
    {
        foreach (var (direction, count) in Instructions)
            ProcessInstruction(direction, count);
    }

    public void SetKnots(int count) => Knots = new (int X, int Y)[count];

    public IReadOnlyList<(char Direction, int Count)> Instructions { get; }

    public (int X, int Y)[] Knots { get; private set; } = Array.Empty<(int X, int Y)>();

    public HashSet<(int X, int Y)> TailVisited { get; } = new() { (0, 0) };
}