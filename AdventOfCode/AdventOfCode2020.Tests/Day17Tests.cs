namespace AdventOfCode2020.Tests;

public class Day17Tests : DayTest<Day17>
{
    private const string TestString1 = @"
.#.
..#
###";

    [Theory]
    [InlineData(TestString1, "112")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "848")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}