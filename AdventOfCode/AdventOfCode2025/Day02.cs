namespace AdventOfCode2025;

public class Day02 : Day<List<(long First, long Last)>>
{
    private static bool HasDuplicates(string input, int parts)
    {
        while (parts > 0)
        {
            if (input.Length % parts != 0)
            {
                parts--;
                continue;
            }

            var partLength = input.Length / parts;
            var partsSet = new HashSet<string>();
            for (var i = 0; i < parts; i++)
            {
                var part = input.Substring(i * partLength, partLength);
                if (!partsSet.Add(part)) return true;
            }

            parts--;
        }

        return false;
    }

    public override string Perform1(string inputString)
    {
        var ranges = ParseInput(inputString);

        var result = 0L;

        foreach (var (first, last) in ranges)
            for (var i = first; i <= last; i++)
                if (HasDuplicates(i.ToString(), 2)) result += i;

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var ranges = ParseInput(inputString);

        var result = 0L;

        foreach (var (first, last) in ranges)
            for (var i = first; i <= last; i++)
                if (HasDuplicates(i.ToString(), i.ToString().Length)) result += i;

        return result.ToString();
    }

    protected override List<(long First, long Last)> ParseInput(string inputString) =>
        inputString
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(row => (long.Parse(row.Split('-')[0]), long.Parse(row.Split('-')[1]))).ToList();
}