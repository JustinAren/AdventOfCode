using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day01Tests
	{
		private const string TestString1 = @"
1721
979
366
299
675
1456";

		private IDay Day { get; } = new Day01();

		[Theory]
		[InlineData(TestString1, 514579)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 241861950)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
