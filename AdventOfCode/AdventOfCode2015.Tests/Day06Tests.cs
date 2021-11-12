namespace AdventOfCode2015.Tests;

public class Day06Tests
{
	private IDay Day { get; } = new Day06();

	private const string InputString = @"
turn on 0,0 through 999,999
toggle 0,0 through 999,0
turn off 499,499 through 500,500";

	[Theory]
	[InlineData(InputString, 998_996)]
	[InlineData("turn on 0,0 through 999,999", 1_000_000)]
	[InlineData("toggle 0,0 through 999,0", 1_000)]
	[InlineData("turn off 499,499 through 500,500", 0)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	//[Theory]
	//[InlineData("", 0)]
	//public void Test2(string inputString, long expected)
	//{
	//	var result = this.Day.Perform2(inputString);
	//	Assert.Equal(expected, result);
	//}
}