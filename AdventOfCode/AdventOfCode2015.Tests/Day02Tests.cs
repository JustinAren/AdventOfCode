namespace AdventOfCode2015.Tests;

public class Day02Tests : DayTest<Day02>
{
    private const string TestString1 = "2x3x4";
    private const string TestString2 = "1x1x10";

    [Theory]
    [InlineData(TestString1, "58")]
    [InlineData(TestString2, "43")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "34")]
    [InlineData(TestString2, "14")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}