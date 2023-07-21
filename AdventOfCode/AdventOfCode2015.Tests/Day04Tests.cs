namespace AdventOfCode2015.Tests;

public class Day04Tests : DayTest<Day04>
{
    private const string TestString1 = "abcdef";
    private const string TestString2 = "pqrstuv";

    [Theory]
    [InlineData(TestString1, "609043")]
    [InlineData(TestString2, "1048970")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "6742839")]
    [InlineData(TestString2, "5714438")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}