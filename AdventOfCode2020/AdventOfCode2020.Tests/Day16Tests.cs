using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day16Tests
	{
		private const string TestString1 = @"
class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

		private IDay Day { get; } = new Day16();

		[Theory]
		[InlineData(TestString1, 71)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		//[Theory]
		//[InlineData(TestString2, 208)]
		//public void Test2(string inputString, ulong expected)
		//{
		//	var result = this.Day.Perform2(inputString);
		//	Assert.Equal(expected, result);
		//}
	}
}
