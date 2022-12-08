namespace AdventOfCode2022.Tests;

public class Day03Tests : DayTest<Day03>
{
    private const string Input = @"
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

    [Theory]
    [InlineData(Input, 157)]
    public override void Test1(string inputString, long expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Input, 70)]
    public override void Test2(string inputString, long expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}