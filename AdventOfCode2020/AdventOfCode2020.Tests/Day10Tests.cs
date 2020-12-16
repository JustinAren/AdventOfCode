using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day10Tests
	{
		private const string TestString1 = @"
16
10
15
5
1
11
7
19
6
12
4";
		
		private const string TestString2 = @"
28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

		private Day Day { get; } = new Day10();

		[Theory]
		[InlineData(TestString1, 35)]
		[InlineData(TestString2, 220)]
		public void Test1(string inputString, ulong expected)
		{
			var result = this.Day.Perform1(inputString);
			Assert.Equal(expected, result);
		}
		
		[Fact]
		public void Test2()
		{
			//var result = this.Day.Perform2(TestString1);
			//Assert.Equal((ulong) 62, result);
		}
	}
}
