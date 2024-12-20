namespace AdventOfCode2024;

public class Day02 : Day<Report[]>
{
    protected override Report[] ParseInput(string inputString)
        => inputString.SplitNewLine().Select(Report.Parse).ToArray();

    public override string Perform1(string inputString)
    {
        var reports = ParseInput(inputString);
        return reports.Count(report => report.IsSafe1()).ToString();
    }

    public override string Perform2(string inputString)
    {
        var reports = ParseInput(inputString);
        return reports.Count(report => report.IsSafe2()).ToString();
    }
}

public record Report(List<int> Levels)
{
    private static bool IsSafe(List<int> levels)
    {
        var increasing = levels[0] < levels[1];
        for (var i = 1; i < levels.Count; i++)
        {
            if (levels[i] == levels[i - 1]
                || Math.Abs(levels[i] - levels[i - 1]) > 3
                || levels[i] > levels[i - 1] != increasing) return false;
        }

        return true;
    }

    public static Report Parse(string row)
    {
        var levels = row.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse).ToList();

        return new Report(levels);
    }

    public bool IsSafe1() => IsSafe(Levels);

    public bool IsSafe2()
    {
        return IsSafe1()
            || Levels.Where((_, i) => IsSafe(Levels.Where((_, index) => index != i).ToList())).Any();
    }
}