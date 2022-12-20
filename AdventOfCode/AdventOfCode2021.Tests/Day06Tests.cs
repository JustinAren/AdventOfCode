namespace AdventOfCode2021.Tests;

public class Day06Tests : DayTest<Day06>
{
    private const string Input = @"3,4,3,1,2";

    [Theory]
    [InlineData(Input, "5934")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "26984457539")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}
