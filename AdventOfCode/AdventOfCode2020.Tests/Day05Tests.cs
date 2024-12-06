namespace AdventOfCode2020.Tests;

public class Day05Tests : DayTest<Day05>
{
    private const string TestString = """
                                      FBFBBFFRLR
                                      BFFFBBFRRR
                                      FFFBBBFRRR
                                      BBFFBBFRLL
                                      FFFFFFFLLL
                                      FFFFFFFLRL
                                      """;

    [Theory]
    [InlineData(TestString, "820")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString, "1")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("FBFBBFFRLR", 357)]
    [InlineData("BFFFBBFRRR", 567)]
    [InlineData("FFFBBBFRRR", 119)]
    [InlineData("BBFFBBFRLL", 820)]
    [InlineData("FFFFFFFLLL", 0)]
    [InlineData("FFFFFFFLRL", 2)]
    public void TestCalculateSeatId(string inputString, int expected)
    {
        var result = Day05.CalculateSeatId(inputString);
        Assert.Equal(expected, result);
    }
}