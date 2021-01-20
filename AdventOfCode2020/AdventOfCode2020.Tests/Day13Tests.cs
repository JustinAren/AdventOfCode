using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day13Tests
	{
		private const string TestString1 = @"
939
7,13,x,x,59,x,31,19";

		private IDay Day { get; } = new Day13();

		[Theory]
		[InlineData(TestString1, 295)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 286)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
