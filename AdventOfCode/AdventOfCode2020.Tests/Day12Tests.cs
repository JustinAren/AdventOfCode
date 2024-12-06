namespace AdventOfCode2020.Tests;

public class Day12Tests : DayTest<Day12>
{
    private const string TestString1 = """
                                       F10
                                       N3
                                       F7
                                       R90
                                       F11
                                       """;

    [Theory]
    [InlineData(TestString1, "25")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "286")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}