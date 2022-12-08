namespace AdventOfCode2022.Tests;

public class Day04Tests : DayTest<Day04>
{
    private const string Input = @"
2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

    [Theory]
    [InlineData(Input, 2)]
    public override void Test1(string inputString, long expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, 4)]
    public override void Test2(string inputString, long expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}