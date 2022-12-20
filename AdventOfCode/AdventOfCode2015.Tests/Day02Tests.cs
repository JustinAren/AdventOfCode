namespace AdventOfCode2015.Tests;

public class Day02Tests : DayTest<Day02>
{
    [Theory]
    [InlineData("2x3x4", "58")]
    [InlineData("1x1x10", "43")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2x3x4", "34")]
    [InlineData("1x1x10", "14")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}