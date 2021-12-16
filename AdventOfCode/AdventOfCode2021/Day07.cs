namespace AdventOfCode2021;

public class Day07 : Day<long[]>
{
	public override long Perform1(string inputString)
	{
		var positions = this.ParseInput(inputString);

		var fuelCosts = CalculateFuelCosts(positions);

		return fuelCosts.Min(tuple => tuple.FuelCost);
	}

	public override long Perform2(string inputString)
	{
		var positions = this.ParseInput(inputString);
		throw new NotImplementedException();
	}

	private static IEnumerable<(long Alignment, long FuelCost)> CalculateFuelCosts(long[] positions)
	{
		var fuelCosts = new List<(long Alignment, long FuelCost)>();
		var alignments = positions.Distinct();

		foreach (var alignment in alignments)
		{
			var fuelCost = positions.Sum(position => Math.Abs(position - alignment));
			fuelCosts.Add((alignment, fuelCost));
		}

		return fuelCosts;
	}

	protected override long[] ParseInput(string inputString)
	{
		return inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int64.Parse).OrderBy(x => x).ToArray();
	}
}
