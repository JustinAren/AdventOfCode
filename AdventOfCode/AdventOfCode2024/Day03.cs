using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class Day03 : Day<string>
{
    [GeneratedRegex(@"mul\((?<X>\d{1,3}),(?<Y>\d{1,3})\)", RegexOptions.Compiled)]
    private static partial Regex MultiplyRegex();

    protected override string ParseInput(string inputString) => inputString;

    public override string Perform1(string inputString)
    {
        return MultiplyRegex().Matches(inputString)
            .Sum(match => int.Parse(match.Groups["X"].Value) * int.Parse(match.Groups["Y"].Value))
            .ToString();
    }

    public override string Perform2(string inputString)
    {
        _ = ParseInput(inputString);
        throw new NotImplementedException();
    }
}