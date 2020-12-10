using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day03Tests
	{
		private const string TestString = @"
..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

		private Day Day03 { get; } = new Day03();

		[Fact]
		public void Test1()
		{
			var result = this.Day03.Perform1(TestString);
			Assert.Equal("7", result);
		}

		[Fact]
		public void Test2()
		{
			//var result = this.Day03.Perform2(TestString);
			//Assert.Equal("", result);
		}
	}
}
