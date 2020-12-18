﻿using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day06Tests
	{
		private const string TestString = @"
abc

a
b
c

ab
ac

a
a
a
a

b";

		private IDay Day { get; } = new Day06();

		[Fact]
		public void Test1()
		{
			var result = this.Day.Perform1(TestString);
			Assert.Equal((ulong) 11, result);
		}

		[Fact]
		public void Test2()
		{
			var result = this.Day.Perform2(TestString);
			Assert.Equal((ulong) 6, result);
		}
	}
}
