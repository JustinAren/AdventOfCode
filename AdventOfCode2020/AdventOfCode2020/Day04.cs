﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
	public class Day04 : Day
	{
		public override string Perform1(string inputString)
		{
			var passportInputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			var passports = passportInputStrings.Select(ParsePassport);
			return passports.Count(p => p.HasRequiredFields).ToString();
		}

		public override string Perform2(string inputString)
		{
			var passportInputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			var passports = passportInputStrings.Select(ParsePassport);
			return passports.Count(p => p.IsValid).ToString();
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