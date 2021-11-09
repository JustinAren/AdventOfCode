using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2015.Tests
{
	public class Day02Tests
	{
		private IDay Day { get; } = new Day02();

		[Theory]
		[InlineData("2x3x4", 58)]
		[InlineData("1x1x10", 43)]
		public void Test1(string inputString, long expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		//[Theory]
		//[InlineData(")", 1)]
		//[InlineData("()())", 5)]
		//public void Test2(string inputString, long expected)
		//{
		//	var result = this.Day.Perform2(inputString);
		//	Assert.Equal(expected, result);
		//}
	}
}
