namespace AdventOfCode2024;

public class Day02 : Day<Report[]>
{
    protected override Report[] ParseInput(string inputString)
        => inputString.SplitNewLine().Select(Report.Parse).ToArray();

    public override string Perform1(string inputString)
    {
        var reports = ParseInput(inputString);
        return reports.Count(report => report.IsSafe()).ToString();
    }

    public override string Perform2(string inputString)
    {
        var input = ParseInput(inputString);
        throw new NotImplementedException();
    }
}

public record Report(int[] Levels)
{
    public static Report Parse(string row)
    {
        var levels = row.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse).ToArray();

        return new Report(levels);
    }

    public bool IsSafe()
    {
        bool? increasing = null;
        for (var i = 1; i < Levels.Length; i++)
        {
            if (Levels[i] == Levels[i - 1]) return false;
            if (Math.Abs(Levels[i] - Levels[i - 1]) > 3) return false;

            if (increasing is null) increasing = Levels[i] > Levels[i - 1];
            else if (Levels[i] > Levels[i - 1] != increasing) return false;
        }

        return true;
    }
}