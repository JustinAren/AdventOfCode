namespace AdventOfCode2015;

public class Day02 : Day<Present[]>
{
    protected override Present[] ParseInput(string inputString)
    {
        var strings = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var result = new Present[strings.Length];
        for (var i = 0; i < strings.Length; i++)
        {
            var splits = strings[i].Split('x', StringSplitOptions.RemoveEmptyEntries);
            result[i] = new Present(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]));
        }

        return result;
    }

    public override string Perform1(string inputString)
    {
        var inputRectangles = ParseInput(inputString);
        var result = inputRectangles.Select(present => present.CalculateWrappingPaperSurface()).Sum();
        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var inputRectangles = ParseInput(inputString);
        var result = inputRectangles.Select(present => present.CalculateRibbonLength()).Sum();
        return result.ToString();
    }
}

public readonly record struct Present(int Length, int Width, int Height)
{
    public int CalculateRibbonLength()
    {
        var bowLength = Length * Width * Height;
        var dimensionOrdered = new[] { Length, Width, Height }.OrderBy(d => d).ToArray();
        var min1 = dimensionOrdered[0];
        var min2 = dimensionOrdered[1];
        return (2 * min1) + (2 * min2) + bowLength;
    }

    public int CalculateWrappingPaperSurface()
    {
        var lwSurface = Length * Width;
        var whSurface = Width * Height;
        var lhSurface = Length * Height;
        var minSurface = Math.Min(Math.Min(lwSurface, whSurface), lhSurface);
        return (2 * lwSurface) + (2 * whSurface) + (2 * lhSurface) + minSurface;
    }
}