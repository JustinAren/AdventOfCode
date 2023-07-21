namespace AdventOfCode2022.Tests;

public class Day09Tests : DayTest<Day09>
{
    private const string Input = """
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2
""";

    [Theory]
    [InlineData(Input, "13")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "8")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}