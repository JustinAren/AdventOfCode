namespace AdventOfCode2015.Tests;

public class Day03Tests
{
	private IDay Day { get; } = new Day03();

	[Theory]
	[InlineData(">", 2)]
	[InlineData("^>v<", 4)]
	[InlineData("^v^v^v^v^v", 2)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData("^v", 3)]
	[InlineData("^>v<", 3)]
	[InlineData("^v^v^v^v^v", 11)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}