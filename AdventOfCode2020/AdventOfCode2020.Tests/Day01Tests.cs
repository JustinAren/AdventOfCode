using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day01Tests
	{
		private const string TestString = @"
1721
979
366
299
675
1456";

		private Day Day { get; } = new Day01();

		[Fact]
		public void Test1()
		{
			var result = this.Day.Perform1(TestString);
			Assert.Equal((ulong) 514579, result);
		}

		[Fact]
		public void Test2()
		{
			var result = this.Day.Perform2(TestString);
			Assert.Equal((ulong) 241861950, result);
		}
	}
}
