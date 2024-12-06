namespace AdventOfCode2020.Tests;

public class Day02Tests : DayTest<Day02>
{
    private const string TestString1 = """
                                       1-3 a: abcde
                                       1-3 b: cdefg
                                       2-9 c: ccccccccc
                                       """;

    [Theory]
    [InlineData(TestString1, "2")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "1")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}