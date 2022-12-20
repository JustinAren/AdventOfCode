namespace AdventOfCode2020.Tests;

public class Day18Tests : DayTest<Day18>
{
    private const string TestString1 = @"1 + 2 * 3 + 4 * 5 + 6";
    private const string TestString2 = @"1 + (2 * 3) + (4 * (5 + 6))";
    private const string TestString3 = @"2 * 3 + (4 * 5)";
    private const string TestString4 = @"5 + (8 * 3 + 9 + 3 * 4 * 3)";
    private const string TestString5 = @"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))";
    private const string TestString6 = @"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

    private const string TestString7 = @"
1 + 2 * 3 + 4 * 5 + 6
1 + (2 * 3) + (4 * (5 + 6))
2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

    [Theory]
    [InlineData(TestString1, "71")]
    [InlineData(TestString2, "51")]
    [InlineData(TestString3, "26")]
    [InlineData(TestString4, "437")]
    [InlineData(TestString5, "12240")]
    [InlineData(TestString6, "13632")]
    [InlineData(TestString7, "26457")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "231")]
    [InlineData(TestString2, "51")]
    [InlineData(TestString3, "46")]
    [InlineData(TestString4, "1445")]
    [InlineData(TestString5, "669060")]
    [InlineData(TestString6, "23340")]
    [InlineData(TestString7, "694173")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}