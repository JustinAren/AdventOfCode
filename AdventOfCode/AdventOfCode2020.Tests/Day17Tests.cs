using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day17Tests
	{
		private const string TestString1 = @"
.#.
..#
###";

		private IDay Day { get; } = new Day17();

		[Theory]
		[InlineData(TestString1, 112)]
		public void Test1(string inputString, long expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 848)]
		public void Test2(string inputString, long expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
