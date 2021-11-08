using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day13Tests
	{
		private const string TestString1 = @"
939
7,13,x,x,59,x,31,19";
		private const string TestString2 = @"
939
17,x,13,19";
		private const string TestString3 = @"
939
67,7,59,61";
		private const string TestString4 = @"
939
67,x,7,59,61";
		private const string TestString5 = @"
939
67,7,x,59,61";
		private const string TestString6 = @"
939
1789,37,47,1889";

		private IDay Day { get; } = new Day13();

		[Theory]
		[InlineData(TestString1, 295)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(TestString1, 1068781)]
		[InlineData(TestString2, 3417)]
		[InlineData(TestString3, 754018)]
		[InlineData(TestString4, 779210)]
		[InlineData(TestString5, 1261476)]
		[InlineData(TestString6, 1202161486)]
		public void Test2(string inputString, ulong expected)
		{
			var result = this.Day.Perform2(inputString);
			Assert.Equal(expected, result);
		}
	}
}
