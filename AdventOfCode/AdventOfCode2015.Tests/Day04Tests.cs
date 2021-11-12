namespace AdventOfCode2015.Tests;

public class Day04Tests
{
	private IDay Day { get; } = new Day04();

	[Theory]
	[InlineData("abcdef", 609043)]
	[InlineData("pqrstuv", 1048970)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData("abcdef", 6742839)]
	[InlineData("pqrstuv", 5714438)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}