namespace AdventOfCode2022;

public class Day04 : Day<AssingmentPair[]>
{
    protected override AssingmentPair[] ParseInput(string inputString) => inputString
        .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(AssingmentPair.Parse)
        .ToArray();

    public override string Perform1(string inputString)
    {
        var assignmentPairs = ParseInput(inputString);
        return assignmentPairs.Count(pair => pair.RangesFullyOverlap).ToString();
    }

    public override string Perform2(string inputString)
    {
        var assignmentPairs = ParseInput(inputString);
        return assignmentPairs.Count(pair => pair.RangesOverlap).ToString();
    }
}

public readonly record struct AssingmentPair(int LowerboundA, int UpperboundA, int LowerboundB, int UpperboundB)
{
    public static AssingmentPair Parse(string inputString)
    {
        var splits = inputString.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var boundsA = splits[0].Split("-", StringSplitOptions.RemoveEmptyEntries);
        var boundsB = splits[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
        return new AssingmentPair(int.Parse(boundsA[0]), int.Parse(boundsA[1]), int.Parse(boundsB[0]),
            int.Parse(boundsB[1]));
    }

    public bool RangesFullyOverlap =>
        (LowerboundA >= LowerboundB && UpperboundA <= UpperboundB) ||
        (LowerboundB >= LowerboundA && UpperboundB <= UpperboundA);

    public bool RangesOverlap =>
        (LowerboundA >= LowerboundB && LowerboundA <= UpperboundB) ||
        (UpperboundA >= LowerboundB && UpperboundA <= UpperboundB) ||
        (LowerboundB >= LowerboundA && LowerboundB <= UpperboundA) ||
        (UpperboundB >= LowerboundA && UpperboundB <= UpperboundA);
}
