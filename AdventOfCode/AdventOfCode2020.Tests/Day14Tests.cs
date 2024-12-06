namespace AdventOfCode2020.Tests;

public class Day14Tests : DayTest<Day14>
{
    private const string TestString1 = """
                                       mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
                                       mem[8] = 11
                                       mem[7] = 101
                                       mem[8] = 0
                                       """;

    private const string TestString2 = """
                                       mask = 000000000000000000000000000000X1001X
                                       mem[42] = 100
                                       mask = 00000000000000000000000000000000X0XX
                                       mem[26] = 1
                                       """;

    [Theory]
    [InlineData(TestString1, "165")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString2, "208")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}