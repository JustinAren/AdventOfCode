namespace AdventOfCode2025.Tests;

public class Day01Tests : DayTest<Day01>
{

    private const string Input = """
                                 L68
                                 L30
                                 R48
                                 L5
                                 R60
                                 L55
                                 L1
                                 L99
                                 R14
                                 L82
                                 """;

    [Theory]
    [InlineData(Input, "3")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "3")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}