using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day04 : Day
	{
		public override string Perform1(string inputString)
		{
			var passportInputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			var passports = passportInputStrings.Select(ParsePassport);
			return passports.Count(p => p.IsValid).ToString();
		}

		public override string Perform2(string inputString)
		{
			throw new NotImplementedException();
		}

		private static Passport ParsePassport(string passportString)
		{
			var passport = new Passport();
			var fields = passportString.Split(new[] {Environment.NewLine, " "}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var field in fields)
			{
				var kvp = field.Split(':', StringSplitOptions.RemoveEmptyEntries);
				switch (kvp[0])
				{
					case "byr": passport.BirthYear = kvp[1]; break;
					case "iyr": passport.IssueYear = kvp[1]; break;
					case "eyr": passport.ExpirationYear = kvp[1]; break;
					case "hgt": passport.Height = kvp[1]; break;
					case "hcl": passport.HairColor = kvp[1]; break;
					case "ecl": passport.EyeColor = kvp[1]; break;
					case "pid": passport.PassportId = kvp[1]; break;
					case "cid": passport.CountryId = kvp[1]; break;
				}
			}

			return passport;
		}
	}

	public class Passport
	{
		public string BirthYear { get; set; }
		public string IssueYear { get; set; }
		public string ExpirationYear { get; set; }
		public string Height { get; set; }
		public string HairColor { get; set; }
		public string EyeColor { get; set; }
		public string PassportId { get; set; }
		public string CountryId { get; set; }

		public bool IsValid => !String.IsNullOrEmpty(this.BirthYear) &&
		                       !String.IsNullOrEmpty(this.IssueYear) &&
		                       !String.IsNullOrEmpty(this.ExpirationYear) &&
		                       !String.IsNullOrEmpty(this.Height) &&
		                       !String.IsNullOrEmpty(this.HairColor) &&
		                       !String.IsNullOrEmpty(this.EyeColor) &&
		                       !String.IsNullOrEmpty(this.PassportId);
	}
}
