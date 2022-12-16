namespace AdventOfCode2021;

public class Day07 : Day<long[]>
{
    protected override long[] ParseInput(string inputString)
    {
        return inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .OrderBy(x => x).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var positions = ParseInput(inputString);
        var fuelCosts = new List<long>();

        foreach (var alignment in Enumerable.Range(0, (int)positions[^1]))
        {
            var fuelCost = positions.Sum(position => Math.Abs(position - alignment));
            fuelCosts.Add(fuelCost);
        }

        return fuelCosts.Min().ToString();
    }

    public override string Perform2(string inputString)
    {
        var positions = ParseInput(inputString);

        var fuelCosts = new List<long>();

        foreach (var alignment in Enumerable.Range(0, (int)positions[^1]))
        {
            var fuelCost = positions.Sum(position =>
                Enumerable.Range(1, (int)Math.Abs(position - alignment)).Sum());
            fuelCosts.Add(fuelCost);
        }

        return fuelCosts.Min().ToString();
    }
}