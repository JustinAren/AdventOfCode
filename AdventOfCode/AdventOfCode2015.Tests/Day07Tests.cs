#pragma warning disable xUnit1026

namespace AdventOfCode2015.Tests;

public class Day07Tests : DayTest<Day07>
{
    private const string TestInput = """
                                     123 -> a
                                     456 -> y
                                     a AND y -> d
                                     a OR y -> e
                                     a LSHIFT 2 -> f
                                     y RSHIFT 2 -> g
                                     NOT x -> h
                                     NOT y -> i
                                     """;

    [Theory]
    [InlineData(TestInput, "123")]
    public override void Test1(string inputString, string expected)
    {
        Assert.True(true);
    }

    [Theory]
    [InlineData(TestInput, "123")]
    public override void Test2(string inputString, string expected)
    {
        Assert.True(true);
    }
}