namespace AdventOfCode2020.Tests;

public class Day12Tests
{
	private const string TestString1 = @"
F10
N3
F7
R90
F11";

	private IDay Day { get; } = new Day12();

	[Theory]
	[InlineData(TestString1, 25)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(TestString1, 286)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}