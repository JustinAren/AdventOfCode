namespace AdventOfCode2020.Tests;

public class Day19Tests
{
	private const string TestString1 = @"
0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

ababbb
bababa
abbbab
aaabbb
aaaabbb
";

	private IDay Day { get; } = new Day19();

	[Theory]
	[InlineData(TestString1, 2)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	//[Theory]
	//[InlineData(TestString1, 231)]
	//public void Test2(string inputString, long expected)
	//{
	//	var result = this.Day.Perform2(inputString);
	//	Assert.Equal(expected, result);
	//}
}