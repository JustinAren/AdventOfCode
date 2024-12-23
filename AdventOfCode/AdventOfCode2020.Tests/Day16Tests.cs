﻿namespace AdventOfCode2020.Tests;

public class Day16Tests : DayTest<Day16>
{
    private const string TestString1 = """
                                       class: 1-3 or 5-7
                                       row: 6-11 or 33-44
                                       seat: 13-40 or 45-50

                                       your ticket:
                                       7,1,14

                                       nearby tickets:
                                       7,3,47
                                       40,4,50
                                       55,2,20
                                       38,6,12
                                       """;

    private const string TestString2 = """
                                       class: 0-1 or 4-19
                                       row: 0-5 or 8-19
                                       seat: 0-13 or 16-19

                                       your ticket:
                                       11,12,13

                                       nearby tickets:
                                       3,9,18
                                       15,1,5
                                       5,14,9
                                       """;

    [Theory]
    [InlineData(TestString1, "71")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString2, "1")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}