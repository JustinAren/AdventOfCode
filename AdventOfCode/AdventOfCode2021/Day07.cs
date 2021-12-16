namespace AdventOfCode2021;

public class Day07 : Day<long[]>
{
	public override long Perform1(string inputString)
	{
		var positions = this.ParseInput(inputString);
		var fuelCosts = new List<long>();

		foreach (var alignment in Enumerable.Range(0, (int) positions[^1]))
		{
			var fuelCost = positions.Sum(position => Math.Abs(position - alignment));
			fuelCosts.Add(fuelCost);
		}

		return fuelCosts.Min();
	}

	public override long Perform2(string inputString)
	{
		var positions = this.ParseInput(inputString);

		var fuelCosts = new List<long>();

		foreach (var alignment in Enumerable.Range(0, (int) positions[^1]))
		{
			var fuelCost = positions.Sum(position => Enumerable.Range(1, (int) Math.Abs(position - alignment)).Sum());
			fuelCosts.Add(fuelCost);
		}

		return fuelCosts.Min();
	}

	protected override long[] ParseInput(string inputString)
	{
		return inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int64.Parse).OrderBy(x => x).ToArray();
	}
}
