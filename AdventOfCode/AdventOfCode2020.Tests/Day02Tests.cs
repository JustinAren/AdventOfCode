using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day02Tests
	{
		private const string TestString1 = @"
1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc
";
		private IDay Day { get; } = new Day02();

		[Theory]
		[InlineData(TestString1, 2)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 1)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
