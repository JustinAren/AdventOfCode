namespace AdventOfCode2020.Tests;

public class Day06Tests : DayTest<Day06>
{
    private const string TestString1 = """
abc

a
b
c

ab
ac

a
a
a
a

b
""";

    [Theory]
    [InlineData(TestString1, "11")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "6")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}