namespace AdventOfCode2025.Tests;

public class Day03Tests : DayTest<Day03>
{
    private const string Input =
        """
        987654321111111
        811111111111119
        234234234234278
        818181911112111
        """;

    [Theory]
    [InlineData(Input, "357")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "3121910778619")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}