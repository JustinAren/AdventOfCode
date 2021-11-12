using AdventOfCodeBase;
using Xunit;

namespace AdventOfCode2015.Tests
{
	public class Day05Tests
	{
		private IDay Day { get; } = new Day05();

		private const string InputString = @"
ugknbfddgicrmopn
aaa
jchzalrnumimnmhp
haegwjzuvuyypxyu
dvszwmarrgswjxmb";

		[Theory]
		[InlineData("ugknbfddgicrmopn")]
		[InlineData("aaa")]
		public void TestIsNice(string name)
		{
			Assert.True(new Name(name).IsNice);
		}

		[Theory]
		[InlineData("jchzalrnumimnmhp")]
		[InlineData("haegwjzuvuyypxyu")]
		[InlineData("dvszwmarrgswjxmb")]
		public void TestIsNaughty(string name)
		{
			Assert.True(new Name(name).IsNaughty);
		}

		[Theory]
		[InlineData(InputString, 2)]
		public void Test1(string inputString, long expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}

		//[Theory]
		//[InlineData("abcdef", 6742839)]
		//[InlineData("pqrstuv", 5714438)]
		//public void Test2(string inputString, long expected)
		//{
		//	var result = this.Day.Perform2(inputString);
		//	Assert.Equal(expected, result);
		//}
	}
}
