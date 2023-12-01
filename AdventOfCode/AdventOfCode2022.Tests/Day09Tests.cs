namespace AdventOfCode2022.Tests;

public class Day09Tests : DayTest<Day09>
{
    private const string Input1 =
        """
        R 4
        U 4
        L 3
        D 1
        R 4
        D 1
        L 5
        R 2
        """;

    private const string Input2 =
        """
        R 5
        U 8
        L 8
        D 3
        R 17
        D 10
        L 25
        U 20
        """;

    [Theory]
    [InlineData(Input1, "13")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input1, "1")]
    [InlineData(Input2, "36")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}