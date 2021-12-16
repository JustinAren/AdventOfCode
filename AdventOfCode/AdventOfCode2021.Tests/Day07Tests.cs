﻿namespace AdventOfCode2021.Tests;

public class Day07Tests : DayTest<Day07>
{
	private const string Input = @"16,1,2,0,4,2,7,1,2,14";

	[Theory]
	[InlineData(Input, 37)]
	public override void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	//[Theory]
	//[InlineData(Input, 26984457539)]
	public override void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}
