namespace AdventOfCode2020.Tests;

public class Day10Tests : DayTest<Day10>
{
    private const string TestString1 = @"
16
10
15
5
1
11
7
19
6
12
4";

    private const string TestString2 = @"
28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

    [Theory]
    [InlineData(TestString1, "35")]
    [InlineData(TestString2, "220")]
    public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(TestString1, "8")]
    [InlineData(TestString2, "19208")]
    public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}