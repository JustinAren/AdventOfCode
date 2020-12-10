using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day01Tests
	{
		private static readonly int[] TestArray = {
			1721,
			979,
			366,
			299,
			675,
			1456,
		};

		private Day Day01 { get; } = new Day01();

		[Fact]
		public void Test1()
		{
			var result = this.Day01.Perform1(TestArray);
			Assert.Equal(514579, result);
		}

		[Fact]
		public void Test2()
		{
			var result = this.Day01.Perform2(TestArray);
			Assert.Equal(241861950, result);
		}
	}
}
