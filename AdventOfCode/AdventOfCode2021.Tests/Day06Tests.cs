namespace AdventOfCode2021.Tests;

public class Day06Tests : DayTest<Day06>
{
	private const string Input = @"3,4,3,1,2";

	[Theory]
	[InlineData(Input, 5934)]
	public override void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	//[Theory]
	//[InlineData(Input, 12)]
	public override void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}
