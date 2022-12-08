namespace AdventOfCode2022;

public class Day04 : Day<AssingmentPair[]>
{
	public override long Perform1(string inputString)
	{
		var assignmentPairs = this.ParseInput(inputString);
		return assignmentPairs.Count(pair => pair.RangeContainsOtherRange);
	}

	public override long Perform2(string inputString) => throw new NotImplementedException();
	protected override AssingmentPair[] ParseInput(string inputString) => inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(AssingmentPair.Parse).ToArray();
}

public readonly record struct AssingmentPair(int LowerboundA, int UpperboundA, int LowerboundB, int UpperboundB)
{
	public bool RangeContainsOtherRange =>
		(this.LowerboundA >= this.LowerboundB && this.UpperboundA <= this.UpperboundB) ||
		(this.LowerboundB >= this.LowerboundA && this.UpperboundB <= this.UpperboundA);

	public static AssingmentPair Parse(string inputString)
	{
		var splits = inputString.Split(",", StringSplitOptions.RemoveEmptyEntries);
		var boundsA = splits[0].Split("-", StringSplitOptions.RemoveEmptyEntries);
		var boundsB = splits[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
		return new AssingmentPair(int.Parse(boundsA[0]), int.Parse(boundsA[1]), int.Parse(boundsB[0]), int.Parse(boundsB[1]));
	}
}
