using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day09Tests
	{
		private const string TestString = @"
35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

		private Day Day { get; } = new Day09();

		[Fact]
		public void Test1()
		{
			var result = this.Day.Perform1(TestString);
			Assert.Equal((ulong) 127, result);
		}
		
		[Fact]
		public void Test2()
		{
			var result = this.Day.Perform2(TestString);
			Assert.Equal((ulong) 62, result);
		}
	}
}
