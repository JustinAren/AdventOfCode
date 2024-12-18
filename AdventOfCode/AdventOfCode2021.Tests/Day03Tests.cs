﻿namespace AdventOfCode2021.Tests;

public class Day03Tests : DayTest<Day03>
{
    private const string Input = """
                                 00100
                                 11110
                                 10110
                                 10111
                                 10101
                                 01111
                                 00111
                                 11100
                                 10000
                                 11001
                                 00010
                                 01010
                                 """;

    [Theory]
    [InlineData(Input, "198")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, "230")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}