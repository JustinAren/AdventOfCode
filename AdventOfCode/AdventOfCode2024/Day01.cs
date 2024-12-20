namespace AdventOfCode2024;

public class Day01 : Day<(List<int> Column1, List<int> Column2)>
{
    protected override (List<int> Column1, List<int> Column2) ParseInput(string inputString)
    {
        var rows = inputString
            .SplitNewLine()
            .Select(row =>
                row.Split("   ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .ToArray();

        var result = (Column1: new List<int>(), Column2: new List<int>());

        foreach (var row in rows)
        {
            result.Column1.Add(int.Parse(row[0]));
            result.Column2.Add(int.Parse(row[1]));
        }

        return result;
    }

    public override string Perform1(string inputString)
    {
        var input = ParseInput(inputString);
        input.Column1.Sort();
        input.Column2.Sort();
        var totalDiff = input.Column1.Select((val, i) => Math.Abs(val - input.Column2[i])).Sum();
        return totalDiff.ToString();
    }

    public override string Perform2(string inputString) => throw new NotImplementedException();
}