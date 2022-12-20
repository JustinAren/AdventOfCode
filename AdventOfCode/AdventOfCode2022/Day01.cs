namespace AdventOfCode2022;

public class Day01 : Day<long[][]>
{
    protected override long[][] ParseInput(string inputString) => inputString
        .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
        .Select(group => group.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToArray())
        .ToArray();

    public override string Perform1(string inputString)
    {
        var groups = ParseInput(inputString);
        return groups.Select(group => group.Sum()).Max().ToString();
    }

    public override string Perform2(string inputString)
    {
        var groups = ParseInput(inputString);
        return groups.Select(group => group.Sum()).OrderByDescending(sum => sum).Take(3).Sum().ToString();
    }
}