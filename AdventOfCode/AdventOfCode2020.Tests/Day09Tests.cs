namespace AdventOfCode2020.Tests;

public class Day09Tests
{
	private const string TestString1 = @"
35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

	private IDay Day { get; } = new Day09();

	[Theory]
	[InlineData(TestString1, 127)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(TestString1, 62)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}