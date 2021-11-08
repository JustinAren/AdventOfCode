using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day15Tests
	{
		private const string TestString1 = @"0,3,6";
		private const string TestString2 = @"1,3,2";
		private const string TestString3 = @"2,1,3";
		private const string TestString4 = @"1,2,3";
		private const string TestString5 = @"2,3,1";
		private const string TestString6 = @"3,2,1";
		private const string TestString7 = @"3,1,2";

		private IDay Day { get; } = new Day15();

		[Theory]
		[InlineData(TestString1, 436)]
		[InlineData(TestString2, 1)]
		[InlineData(TestString3, 10)]
		[InlineData(TestString4, 27)]
		[InlineData(TestString5, 78)]
		[InlineData(TestString6, 438)]
		[InlineData(TestString7, 1836)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 175594)]
		[InlineData(TestString2, 2578)]
		[InlineData(TestString3, 3544142)]
		[InlineData(TestString4, 261214)]
		[InlineData(TestString5, 6895259)]
		[InlineData(TestString6, 18)]
		[InlineData(TestString7, 362)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
