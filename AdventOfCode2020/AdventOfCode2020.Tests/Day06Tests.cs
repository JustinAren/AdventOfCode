using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day06Tests
	{
		private const string TestString1 = @"
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

		[Theory]
		[InlineData(TestString1, 11)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 6)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
