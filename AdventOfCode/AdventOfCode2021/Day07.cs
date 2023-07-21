namespace AdventOfCode2021;

public class Day07 : Day<long[]>
{
    protected override long[] ParseInput(string inputString)
    {
        return inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .OrderBy(row => row).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var positions = ParseInput(inputString);
        var fuelCosts = Enumerable.Range(0, (int)positions[^1])
            .Select(alignment => positions.Sum(position => Math.Abs(position - alignment)))
            .ToList();

        return fuelCosts.Min().ToString();
    }

    public override string Perform2(string inputString)
    {
        var positions = ParseInput(inputString);

        var fuelCosts = Enumerable.Range(0, (int)positions[^1])
            .Select(alignment =>
                positions.Sum(position => Enumerable.Range(1, (int)Math.Abs(position - alignment)).Sum()))
            .Select(fuelCost => (long)fuelCost)
            .ToList();

        return fuelCosts.Min().ToString();
    }
}