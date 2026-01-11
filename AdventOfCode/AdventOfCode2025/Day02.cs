namespace AdventOfCode2025;

public class Day02 : Day<List<(long First, long Last)>>
{
    public override string Perform1(string inputString)
    {
        var ranges = ParseInput(inputString);

        var result = 0L;

        foreach (var (first, last) in ranges)
        {
            for (var i = first; i <= last; i++)
            {
                var id = i.ToString();
                var idHalf = id.Length / 2;
                if (id[..idHalf] == id[idHalf..]) result += i;
            }
        }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var result = 0;
        return result.ToString();
    }

    protected override List<(long First, long Last)> ParseInput(string inputString) =>
        inputString
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(row => (long.Parse(row.Split('-')[0]), long.Parse(row.Split('-')[1]))).ToList();
}