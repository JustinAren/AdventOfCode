namespace AdventOfCode2023;

public class Day01 : Day<int[]>
{
    protected override int[] ParseInput(string inputString) => inputString
        .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(row => int.Parse($"{row.First(char.IsDigit)}{row.Reverse().First(char.IsDigit)}"))
        .ToArray();

    public override string Perform1(string inputString)
    {
        var integers = ParseInput(inputString);
        return integers.Sum().ToString();
    }

    public override string Perform2(string inputString)
    {
        var groups = ParseInput(inputString);
        return "";
    }
}