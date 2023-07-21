namespace AdventOfCode2015.Tests;

public class Day06Tests : DayTest<Day06>
{
    private const string InputString1 = """
turn on 0,0 through 999,999
toggle 0,0 through 999,0
turn off 499,499 through 500,500
""";

    private const string InputString2 = """
turn on 0,0 through 0,0
toggle 0,0 through 999,999
""";

    [Theory]
    [InlineData(InputString1, "998996")]
    [InlineData(InputString2, "999999")]
    [InlineData("turn on 0,0 through 999,999", "1000000")]
    [InlineData("toggle 0,0 through 999,0", "1000")]
    [InlineData("turn off 499,499 through 500,500", "0")]
    [InlineData("turn on 0,0 through 0,0", "1")]
    [InlineData("toggle 0,0 through 999,999", "1000000")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(InputString1, "1001996")]
    [InlineData(InputString2, "2000001")]
    [InlineData("turn on 0,0 through 999,999", "1000000")]
    [InlineData("toggle 0,0 through 999,0", "2000")]
    [InlineData("turn off 499,499 through 500,500", "0")]
    [InlineData("turn on 0,0 through 0,0", "1")]
    [InlineData("toggle 0,0 through 999,999", "2000000")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}