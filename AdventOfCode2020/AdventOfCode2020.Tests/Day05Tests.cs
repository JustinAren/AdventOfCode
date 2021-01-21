using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day05Tests
	{

		private const string TestString = @"
FBFBBFFRLR
BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL
FFFFFFFLLL
FFFFFFFLRL";

		private IDay Day { get; } = new Day05();

		[Theory]
		[InlineData("FBFBBFFRLR", 357)]
		[InlineData("BFFFBBFRRR", 567)]
		[InlineData("FFFBBBFRRR", 119)]
		[InlineData("BBFFBBFRLL", 820)]
		[InlineData("FFFFFFFLLL", 0)]
		[InlineData("FFFFFFFLRL", 2)]
		public void TestCalculateSeatId(string inputString, int expected)
		{
			var result = Day05.CalculateSeatId(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString, 820)]
		public void Test1(string input, ulong expected)
		{
			var result = this.Day.Perform1(input);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString, 1)]
		public void Test2(string input, ulong expected)
		{
			var result = this.Day.Perform2(input);
			Assert.Equal(expected, result);
		}
	}
}
