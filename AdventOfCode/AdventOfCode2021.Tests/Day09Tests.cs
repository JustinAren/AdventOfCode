namespace AdventOfCode2021.Tests;

public class Day09Tests : DayTest<Day09>
{
    private const string Input = """
                                 2199943210
                                 3987894921
                                 9856789892
                                 8767896789
                                 9899965678
                                 """;

    [Theory]
    [InlineData(Input, "15")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "1134")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}