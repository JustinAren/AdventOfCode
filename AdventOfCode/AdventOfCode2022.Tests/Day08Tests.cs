namespace AdventOfCode2022.Tests;

public class Day08Tests : DayTest<Day08>
{
    private const string Input = @"
30373
25512
65332
33549
35390";

    [Theory]
    [InlineData(Input, "21")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "8")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}