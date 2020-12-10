﻿using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day02Tests
	{
		private const string TestString = @"
1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc
";
		private Day02 Day02 { get; } = new Day02();

		[Fact]
		public void Test1()
		{
			var result = this.Day02.Perform1(TestString);
			Assert.Equal("2", result);
		}

		[Fact]
		public void Test2()
		{
			var result = this.Day02.Perform2(TestString);
			Assert.Equal("241861950", result);
		}
	}
}