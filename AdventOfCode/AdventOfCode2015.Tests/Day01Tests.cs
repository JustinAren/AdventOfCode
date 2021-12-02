namespace AdventOfCode2015.Tests;

public class Day01Tests : DayTest<Day01>
{
	[Theory]
	[InlineData("(())", 0)]
	[InlineData("()()", 0)]
	[InlineData("(((", 3)]
	[InlineData("(()(()(", 3)]
	[InlineData("))(((((", 3)]
	[InlineData("())", -1)]
	[InlineData("))(", -1)]
	[InlineData(")))", -3)]
	[InlineData(")())())", -3)]
	public override void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(")", 1)]
	[InlineData("()())", 5)]
	public override void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}