namespace AdventOfCode2020.Tests;

public class Day09Tests : DayTest<Day09>
{
    private const string TestString1 = """
                                       35
                                       20
                                       15
                                       25
                                       47
                                       40
                                       62
                                       55
                                       65
                                       95
                                       102
                                       117
                                       150
                                       182
                                       127
                                       219
                                       299
                                       277
                                       309
                                       576
                                       """;

    [Theory]
    [InlineData(TestString1, "127")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "62")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}