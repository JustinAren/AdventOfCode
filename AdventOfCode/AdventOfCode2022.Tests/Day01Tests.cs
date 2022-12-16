namespace AdventOfCode2022.Tests;

public class Day01Tests : DayTest<Day01>
{
    private const string Input = @"
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [Theory]
    [InlineData(Input, "24000")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "45000")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}