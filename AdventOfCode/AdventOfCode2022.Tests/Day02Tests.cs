namespace AdventOfCode2022.Tests;

public class Day02Tests : DayTest<Day02>
{
    private const string Input = """
                                 A Y
                                 B X
                                 C Z
                                 """;

    [Theory]
    [InlineData(Input, "15")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "12")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}