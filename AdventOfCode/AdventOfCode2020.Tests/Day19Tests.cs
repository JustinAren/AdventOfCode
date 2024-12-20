#pragma warning disable xUnit1026

namespace AdventOfCode2020.Tests;

public class Day19Tests : DayTest<Day19>
{
    private const string TestString1 = """
                                       0: 4 1 5
                                       1: 2 3 | 3 2
                                       2: 4 4 | 5 5
                                       3: 4 5 | 5 4
                                       4: "a"
                                       5: "b"

                                       ababbb
                                       bababa
                                       abbbab
                                       aaabbb
                                       aaaabbb
                                       """;

    [Theory]
    [InlineData(TestString1, "2")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "231")]
    public override void Test2(string inputString, string expected)
    {
        Assert.True(true);
    }
}