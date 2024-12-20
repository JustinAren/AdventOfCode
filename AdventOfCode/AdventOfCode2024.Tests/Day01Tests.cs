namespace AdventOfCode2024.Tests;

public class Day01Tests : DayTest<Day01>
{
    private const string Input = """
                                 3   4
                                 4   3
                                 2   5
                                 1   3
                                 3   9
                                 3   3
                                 """;

    [Theory]
    [InlineData(Input, "11")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "281")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}