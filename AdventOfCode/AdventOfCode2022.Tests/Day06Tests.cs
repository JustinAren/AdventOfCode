namespace AdventOfCode2022.Tests;

public class Day06Tests : DayTest<Day06>
{
    private const string Input1 = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";
	private const string Input2 = @"bvwbjplbgvbhsrlpgdmjqwftvncz";
	private const string Input3 = @"nppdvjthqldpwncqszvftbrmjlhg";
	private const string Input4 = @"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
	private const string Input5 = @"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";

	[Theory]
    [InlineData(Input1, "7")]
	[InlineData(Input2, "5")]
	[InlineData(Input3, "6")]
	[InlineData(Input4, "10")]
	[InlineData(Input5, "11")]
	public override void Test1(string inputString, string expected)
    {
        var result = Day.Perform1(inputString);
        Assert.Equal(expected, result);
    }

    [Theory]
	[InlineData(Input1, "19")]
	[InlineData(Input2, "23")]
	[InlineData(Input3, "23")]
	[InlineData(Input4, "29")]
	[InlineData(Input5, "26")]
	public override void Test2(string inputString, string expected)
    {
        var result = Day.Perform2(inputString);
        Assert.Equal(expected, result);
    }
}