namespace AdventOfCode2015.Tests;

public class Day03Tests : DayTest<Day03>
{
    private const string TestString1 = "^>v<";
    private const string TestString2 = "^v^v^v^v^v";

    [Theory]
    [InlineData(">", "2")]
    [InlineData(TestString1, "4")]
    [InlineData(TestString2, "2")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("^v", "3")]
    [InlineData(TestString1, "3")]
    [InlineData(TestString2, "11")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}