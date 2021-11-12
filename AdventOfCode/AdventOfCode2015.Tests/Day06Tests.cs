namespace AdventOfCode2015.Tests;

public class Day06Tests
{
	private IDay Day { get; } = new Day06();

	private const string InputString1 = @"
turn on 0,0 through 999,999
toggle 0,0 through 999,0
turn off 499,499 through 500,500";

	private const string InputString2 = @"
turn on 0,0 through 0,0
toggle 0,0 through 999,999";

	[Theory]
	[InlineData(InputString1, 998_996)]
	[InlineData(InputString2, 999_999)]
	[InlineData("turn on 0,0 through 999,999", 1_000_000)]
	[InlineData("toggle 0,0 through 999,0", 1_000)]
	[InlineData("turn off 499,499 through 500,500", 0)]
	[InlineData("turn on 0,0 through 0,0", 1)]
	[InlineData("toggle 0,0 through 999,999", 1_000_000)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(InputString1, 1_001_996)]
	[InlineData(InputString2, 2_000_001)]
	[InlineData("turn on 0,0 through 999,999", 1_000_000)]
	[InlineData("toggle 0,0 through 999,0", 2_000)]
	[InlineData("turn off 499,499 through 500,500", 0)]
	[InlineData("turn on 0,0 through 0,0", 1)]
	[InlineData("toggle 0,0 through 999,999", 2_000_000)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}