using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day08Tests
	{
		private const string TestString1 = @"
nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

		private IDay Day { get; } = new Day08();

		[Theory]
		[InlineData(TestString1, 5)]
		public void Test1(string inputString, long expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 8)]
		public void Test2(string inputString, long expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
