using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public partial class Day01 : Day<string[]>
{
    [GeneratedRegex("[a-z]")]
    private static partial Regex Alphabet();

    protected override string[] ParseInput(string inputString) => inputString.SplitNewLine();

    public override string Perform1(string inputString)
    {
        return ParseInput(inputString)
            .Select(line => Alphabet().Replace(line, ""))
            .Select(line => $"{line.First()}{line.Last()}")
            .Select(int.Parse)
            .Sum()
            .ToString();
    }

    public override string Perform2(string inputString)
    {
        var replaces = new Dictionary<string, string>
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "4" },
            { "five", "5e" },
            { "six", "6" },
            { "seven", "7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };

        return ParseInput(inputString)
            .Select(line =>
                replaces.Aggregate(line, (current, replace) => current.Replace(replace.Key, replace.Value)))
            .Select(line => Alphabet().Replace(line, ""))
            .Select(line => $"{line.First()}{line.Last()}")
            .Select(int.Parse)
            .Sum()
            .ToString();
    }
}