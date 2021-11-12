namespace AdventOfCode2015.Tests;

public class Day05Tests
{
	private IDay Day { get; } = new Day05();

	private const string InputString1 = @"
ugknbfddgicrmopn
aaa
jchzalrnumimnmhp
haegwjzuvuyypxyu
dvszwmarrgswjxmb";

	private const string InputString2 = @"
qjhvhtzxzqqjkmpb
xxyxx
uurcxstgmygtbstg
ieodomkazucvgmuy";

	[Theory]
	[InlineData("ugknbfddgicrmopn", true)]
	[InlineData("aaa", true)]
	[InlineData("jchzalrnumimnmhp", false)]
	[InlineData("haegwjzuvuyypxyu", false)]
	[InlineData("dvszwmarrgswjxmb", false)]
	[InlineData("qjhvhtzxzqqjkmpb", false)]
	[InlineData("xxyxx", false)]
	[InlineData("ieodomkazucvgmuy", false)]
	public void TestIsNice1(string name, bool isNice)
	{
		Assert.Equal(isNice, new Name(name).IsNice1);
	}

	[Theory]
	[InlineData(InputString1, 2)]
	[InlineData(InputString2, 0)]
	public void Test1(string inputString, long expected)
	{
		var result = this.Day.Perform1(inputString);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData("qjhvhtzxzqqjkmpb", true)]
	[InlineData("xxyxx", true)]
	[InlineData("jchzalrnumimnmhp", false)]
	[InlineData("haegwjzuvuyypxyu", false)]
	[InlineData("dvszwmarrgswjxmb", false)]
	[InlineData("ieodomkazucvgmuy", false)]
	[InlineData("aaa", false)]
	[InlineData("ugknbfddgicrmopn", false)]
	public void TestIsNice2(string name, bool isNice)
	{
		Assert.Equal(isNice, new Name(name).IsNice2);
	}

	[Theory]
	[InlineData(InputString1, 0)]
	[InlineData(InputString2, 2)]
	public void Test2(string inputString, long expected)
	{
		var result = this.Day.Perform2(inputString);
		Assert.Equal(expected, result);
	}
}