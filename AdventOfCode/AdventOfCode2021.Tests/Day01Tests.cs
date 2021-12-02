namespace AdventOfCode2021.Tests;

public class Day01Tests : DayTest<Day01>
{
	private const string Input = @"
199
200
208
210
200
207
240
269
260
263";

	[Theory]
	[InlineData(Input, 7)]
	public override void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(Input, 5)]
	public override void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}