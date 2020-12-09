using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day01Tests
	{
		[Fact]
		public void Test1()
		{
			var testArray = new[] {
				1721,
				979,
				366,
				299,
				675,
				1456,
			};

			var result = Day01.Perform(testArray);

			Assert.Equal(514579, result);
		}
	}
}
