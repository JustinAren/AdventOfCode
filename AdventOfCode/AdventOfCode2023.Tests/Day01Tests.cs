namespace AdventOfCode2023.Tests;

public class Day01Tests : DayTest<Day01>
{
    private const string Input = """
                                 1abc2
                                 pqr3stu8vwx
                                 a1b2c3d4e5f
                                 treb7uchet
                                 """;

    [Theory]
    [InlineData(Input, "142")]
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