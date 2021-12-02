namespace AdventOfCode2021;

public class Day01 : Day<List<int>>
{
	public override long Perform1(string inputString)
	{
		var heights = this.ParseInput(inputString);
		var increments = 0;

		var current = heights[0];

		for (var i = 1; i < heights.Count; i++)
		{
			if (heights[i] > current) increments++;
			current = heights[i];
		}

		return increments;
	}

	public override long Perform2(string inputString)
	{
		var heights = this.ParseInput(inputString);
		var increments = 0;

		var currentSum = heights.Take(3).Sum();

		for (var i = 1; i < heights.Count - 2; i++)
		{
			var slidingSum = new[] { heights[i], heights[i + 1], heights[i + 2] }.Sum();
			if (slidingSum > currentSum) increments++;
			currentSum = slidingSum;
		}

		return increments;
	}

	protected override List<int> ParseInput(string inputString) => inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
}
