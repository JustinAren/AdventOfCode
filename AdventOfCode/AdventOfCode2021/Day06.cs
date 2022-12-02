namespace AdventOfCode2021;

public class Day06 : Day<long[]>
{
    private static void Simulate(long[] counters, int numberOfDays)
    {
        while (numberOfDays > 0)
        {
            var reproducingCount = counters[0];

            for (var i = 0; i < counters.Length - 1; i++) counters[i] = counters[i + 1];

            counters[6] += reproducingCount;
            counters[8] = reproducingCount;

            numberOfDays--;
        }
    }

    protected override long[] ParseInput(string inputString)
    {
        var countDictionary = inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).GroupBy(x => x)
            .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
        var result = new long[9];
        foreach (var (key, value) in countDictionary) result[key] = value;

        return result;
    }

    public override long Perform1(string inputString)
    {
        var fishCounters = ParseInput(inputString);
        Simulate(fishCounters, 80);
        return fishCounters.Sum();
    }

    public override long Perform2(string inputString)
    {
        var fishCounters = ParseInput(inputString);
        Simulate(fishCounters, 256);
        return fishCounters.Sum();
    }
}