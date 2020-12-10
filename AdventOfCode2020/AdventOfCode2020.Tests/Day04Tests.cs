using Xunit;

namespace AdventOfCode2020.Tests
{
	public class Day04Tests
	{
		private const string TestString = @"
ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

		private Day Day04 { get; } = new Day04();

		[Fact]
		public void Test1()
		{
			var result = this.Day04.Perform1(TestString);
			Assert.Equal("2", result);
		}

		[Fact]
		public void Test2()
		{
			//var result = this.Day04.Perform2(TestString);
			//Assert.Equal("336", result);
		}
	}
}
