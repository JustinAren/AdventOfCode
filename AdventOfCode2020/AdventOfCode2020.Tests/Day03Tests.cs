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

		private Day Day { get; } = new Day03();

		[Fact]
		public void Test1()
		{
			var result = this.Day.Perform1(TestString);
			Assert.Equal("7", result);
		}

		[Fact]
		public void Test2()
		{
			var result = this.Day.Perform2(TestString);
			Assert.Equal("336", result);
		}
	}
}
