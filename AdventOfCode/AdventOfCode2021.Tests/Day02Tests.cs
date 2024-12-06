namespace AdventOfCode2021.Tests;

public class Day02Tests : DayTest<Day02>
{
    private const string Input = """
                                 forward 5
                                 down 5
                                 forward 8
                                 up 3
                                 down 8
                                 forward 2
                                 """;

    [Theory]
    [InlineData(Input, "150")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "900")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}