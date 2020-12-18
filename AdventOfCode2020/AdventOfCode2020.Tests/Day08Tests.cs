using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day08Tests
	{
		private const string TestString = @"
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

		[Fact]
		public void Test1()
		{
			var result = this.Day.Perform1(TestString);
			Assert.Equal((ulong) 5, result);
		}
		
		[Fact]
		public void Test2()
		{
			var result = this.Day.Perform2(TestString);
			Assert.Equal((ulong) 8, result);
		}
	}
}
