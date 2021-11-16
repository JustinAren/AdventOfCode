namespace AdventOfCode2020.Tests;

public class Day01Tests : DayTest<Day01>
{
	private const string TestString1 = @"
1721
979
366
299
675
1456";
	
	[Theory]
	[InlineData(TestString1, 514579)]
	public override void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(TestString1, 241861950)]
	public override void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}