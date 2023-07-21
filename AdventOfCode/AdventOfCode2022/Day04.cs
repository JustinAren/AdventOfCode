namespace AdventOfCode2022;

public class Day04 : Day<AssignmentPair[]>
{
    protected override AssignmentPair[] ParseInput(string inputString) => inputString
        .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(AssignmentPair.Parse)
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

public readonly record struct AssignmentPair(int LowerBoundA, int UpperBoundA, int LowerBoundB, int UpperBoundB)
{
    public static AssignmentPair Parse(string inputString)
    {
        var splits = inputString.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var boundsA = splits[0].Split("-", StringSplitOptions.RemoveEmptyEntries);
        var boundsB = splits[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
        return new AssignmentPair(int.Parse(boundsA[0]), int.Parse(boundsA[1]), int.Parse(boundsB[0]),
            int.Parse(boundsB[1]));
    }

    public bool RangesFullyOverlap =>
        (LowerBoundA >= LowerBoundB && UpperBoundA <= UpperBoundB) ||
        (LowerBoundB >= LowerBoundA && UpperBoundB <= UpperBoundA);

    public bool RangesOverlap =>
        (LowerBoundA >= LowerBoundB && LowerBoundA <= UpperBoundB) ||
        (UpperBoundA >= LowerBoundB && UpperBoundA <= UpperBoundB) ||
        (LowerBoundB >= LowerBoundA && LowerBoundB <= UpperBoundA) ||
        (UpperBoundB >= LowerBoundA && UpperBoundB <= UpperBoundA);
}