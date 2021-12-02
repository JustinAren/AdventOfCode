namespace AdventOfCode2021;

public class Day01 : Day<List<int>>
{
	public override long Perform1(string inputString)
	{
		var heights = this.ParseInput(inputString);
		var current = heights[0];
		var increments = 0;

		foreach (var height in heights.Skip(1))
		{
			if (height > current) increments++;
			current = height;
		}

		return increments;
	}

	public override long Perform2(string inputString) => throw new NotImplementedException();

	protected override List<int> ParseInput(string inputString)
	{
		var result = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
		return result;
	}
}
