using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day04 : Day<IEnumerable<Passport>>
	{
		public override ulong Perform1(string inputString)
		{
			var passports = this.ParseInput(inputString);
			return (ulong) passports.Count(p => p.HasRequiredFields);
		}

		public override ulong Perform2(string inputString)
		{
			var passports = this.ParseInput(inputString);
			return (ulong) passports.Count(p => p.IsValid);
		}

		protected override IEnumerable<Passport> ParseInput(string inputString)
		{
			var passportInputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			return passportInputStrings.Select(ParsePassport);
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
		private static readonly string[] ValidEyeColors = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

		public string BirthYear { get; set; }
		public string IssueYear { get; set; }
		public string ExpirationYear { get; set; }
		public string Height { get; set; }
		public string HairColor { get; set; }
		public string EyeColor { get; set; }
		public string PassportId { get; set; }
		public string CountryId { get; set; }

		public bool HasRequiredFields => 
			!String.IsNullOrEmpty(this.BirthYear) &&
			!String.IsNullOrEmpty(this.IssueYear) &&
			!String.IsNullOrEmpty(this.ExpirationYear) &&
			!String.IsNullOrEmpty(this.Height) &&
			!String.IsNullOrEmpty(this.HairColor) &&
			!String.IsNullOrEmpty(this.EyeColor) &&
			!String.IsNullOrEmpty(this.PassportId);

		public bool IsBirthYearValid => !String.IsNullOrEmpty(this.BirthYear) && Int32.TryParse(this.BirthYear, out var birthYear) && birthYear >= 1920 && birthYear <= 2002;
		public bool IsIssueYearValid => !String.IsNullOrEmpty(this.IssueYear) && Int32.TryParse(this.IssueYear, out var issueYear) && issueYear >= 2010 && issueYear <= 2020;
		public bool IsExpirationYearValid => !String.IsNullOrEmpty(this.ExpirationYear) && Int32.TryParse(this.ExpirationYear, out var expirationYear) && expirationYear >= 2020 && expirationYear <= 2030;
		public bool IsHeightValid => !String.IsNullOrEmpty(this.Height) && ValidateHeight(this.Height);

		private static bool ValidateHeight(string height)
		{
			if (height.EndsWith("in"))
			{
				height = height.Replace("in", "");
				if (!Int32.TryParse(height, out var heightInt)) return false;
				return heightInt >= 59 && heightInt <= 76;
			}

			if (height.EndsWith("cm"))
			{
				height = height.Replace("cm", "");
				if (!Int32.TryParse(height, out var heightInt)) return false;
				return heightInt >= 150 && heightInt <= 193;
			}

			return false;
		}

		public bool IsHairColorValid => !String.IsNullOrEmpty(this.HairColor) && Regex.IsMatch(this.HairColor, @"^#[0-9a-f]{6}$");
		public bool IsEyeColorValid => !String.IsNullOrEmpty(this.EyeColor) && ValidEyeColors.Contains(this.EyeColor);
		public bool IsPassportIdValid => !String.IsNullOrEmpty(this.PassportId) && Regex.IsMatch(this.PassportId, @"^[0-9]{9}$");

		public bool IsValid => 
			this.HasRequiredFields && 
			this.IsBirthYearValid && 
			this.IsIssueYearValid && 
			this.IsExpirationYearValid && 
			this.IsHeightValid && 
			this.IsHairColorValid && 
			this.IsEyeColorValid && 
			this.IsPassportIdValid;
	}
}
