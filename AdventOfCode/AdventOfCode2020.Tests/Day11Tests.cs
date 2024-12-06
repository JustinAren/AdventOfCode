namespace AdventOfCode2020.Tests;

public class Day11Tests : DayTest<Day11>
{
    private const string TestString1 = """
                                       L.LL.LL.LL
                                       LLLLLLL.LL
                                       L.L.L..L..
                                       LLLL.LL.LL
                                       L.LL.LL.LL
                                       L.LLLLL.LL
                                       ..L.L.....
                                       LLLLLLLLLL
                                       L.LLLLLL.L
                                       L.LLLLL.LL
                                       """;

    [Theory]
    [InlineData(TestString1, "37")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "26")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}