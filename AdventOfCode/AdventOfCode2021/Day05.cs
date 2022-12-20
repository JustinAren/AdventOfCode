namespace AdventOfCode2021;

public class Day05 : Day<Line[]>
{
    protected override Line[] ParseInput(string inputString)
    {
        var result = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Line.Parse).ToArray();
        return result;
    }

    public override string Perform1(string inputString)
    {
        var gridDictionary = new Dictionary<(int X, int Y), int>();
        var lines = ParseInput(inputString);
        foreach (var line in lines)
        {
            if (line.IsHorizontal)
            {
                var lowerBound = Math.Min(line.X1, line.X2);
                var upperBound = Math.Max(line.X1, line.X2);

                for (var i = lowerBound; i <= upperBound; i++)
                {
                    var coordinate = (i, line.Y1);
                    if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
                    else gridDictionary.Add(coordinate, 1);
                }
            }
            else if (line.IsVertical)
            {
                var lowerBound = Math.Min(line.Y1, line.Y2);
                var upperBound = Math.Max(line.Y1, line.Y2);

                for (var i = lowerBound; i <= upperBound; i++)
                {
                    var coordinate = (line.X1, i);
                    if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
                    else gridDictionary.Add(coordinate, 1);
                }
            }
        }

        var overlapCount = gridDictionary.Count(kvp => kvp.Value > 1);
        return overlapCount.ToString();
    }

    public override string Perform2(string inputString)
    {
        var gridDictionary = new Dictionary<(int X, int Y), int>();
        var lines = ParseInput(inputString);
        foreach (var line in lines)
        {
            if (line.IsHorizontal)
            {
                var lowerBound = Math.Min(line.X1, line.X2);
                var upperBound = Math.Max(line.X1, line.X2);

                for (var i = lowerBound; i <= upperBound; i++)
                {
                    var coordinate = (i, line.Y1);
                    if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
                    else gridDictionary.Add(coordinate, 1);
                }
            }
            else if (line.IsVertical)
            {
                var lowerBound = Math.Min(line.Y1, line.Y2);
                var upperBound = Math.Max(line.Y1, line.Y2);

                for (var i = lowerBound; i <= upperBound; i++)
                {
                    var coordinate = (line.X1, i);
                    if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
                    else gridDictionary.Add(coordinate, 1);
                }
            }
            else if (line.IsDiagonal)
            {
                for (var i = 0; i <= Math.Abs(line.X1 - line.X2); i++)
                {
                    var coordinate = line.X1 > line.X2
                        ? line.Y1 > line.Y2
                            ? (line.X1 - i, line.Y1 - i)
                            : (line.X1 - i, line.Y1 + i)
                        : line.Y1 > line.Y2
                            ? (line.X1 + i, line.Y1 - i)
                            : (line.X1 + i, line.Y1 + i);
                    if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
                    else gridDictionary.Add(coordinate, 1);
                }
            }
        }

        var overlapCount = gridDictionary.Count(kvp => kvp.Value > 1);
        return overlapCount.ToString();
    }
}

public readonly record struct Line(int X1, int X2, int Y1, int Y2)
{
    public static Line Parse(string line)
    {
        var parts = line.Split(" -> ");
        var x1y1 = parts[0].Split(',');
        var x2y2 = parts[1].Split(',');
        return new Line(int.Parse(x1y1[0]), int.Parse(x2y2[0]), int.Parse(x1y1[1]), int.Parse(x2y2[1]));
    }

    public bool IsDiagonal => Math.Abs(X1 - X2) == Math.Abs(Y1 - Y2);

    public bool IsHorizontal => Y1 == Y2;

    public bool IsVertical => X1 == X2;
}