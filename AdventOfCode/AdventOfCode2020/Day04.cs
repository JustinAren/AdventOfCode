using System.Text.RegularExpressions;

namespace AdventOfCode2020;

public class Day04 : Day<IEnumerable<Passport>>
{
    private static Passport ParsePassport(string passportString)
    {
        var passport = new Passport();
        var fields = passportString.Split(new[] { Environment.NewLine, " " },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (var field in fields)
        {
            var kvp = field.Split(':', StringSplitOptions.RemoveEmptyEntries);
            switch (kvp[0])
            {
                case "byr":
                    passport.BirthYear = kvp[1];
                    break;
                case "iyr":
                    passport.IssueYear = kvp[1];
                    break;
                case "eyr":
                    passport.ExpirationYear = kvp[1];
                    break;
                case "hgt":
                    passport.Height = kvp[1];
                    break;
                case "hcl":
                    passport.HairColor = kvp[1];
                    break;
                case "ecl":
                    passport.EyeColor = kvp[1];
                    break;
                case "pid":
                    passport.PassportId = kvp[1];
                    break;
                case "cid":
                    passport.CountryId = kvp[1];
                    break;
            }
        }

        return passport;
    }

    protected override IEnumerable<Passport> ParseInput(string inputString)
    {
        var passportInputStrings = inputString.Split($"{Environment.NewLine}{Environment.NewLine}",
            StringSplitOptions.RemoveEmptyEntries);
        return passportInputStrings.Select(ParsePassport);
    }

    public override string Perform1(string inputString)
    {
        var passports = ParseInput(inputString);
        return passports.Count(p => p.HasRequiredFields).ToString();
    }

    public override string Perform2(string inputString)
    {
        var passports = ParseInput(inputString);
        return passports.Count(p => p.IsValid).ToString();
    }
}

public class Passport
{
    private static readonly string[] ValidEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

    private static bool ValidateHeight(string height)
    {
        if (height.EndsWith("in"))
        {
            height = height.Replace("in", "");
            if (!int.TryParse(height, out var heightInt)) return false;
            return heightInt >= 59 && heightInt <= 76;
        }

        if (height.EndsWith("cm"))
        {
            height = height.Replace("cm", "");
            if (!int.TryParse(height, out var heightInt)) return false;
            return heightInt >= 150 && heightInt <= 193;
        }

        return false;
    }

    public string BirthYear { get; set; }

    public string CountryId { get; set; }

    public string ExpirationYear { get; set; }

    public string EyeColor { get; set; }

    public string HairColor { get; set; }

    public bool HasRequiredFields =>
        !string.IsNullOrEmpty(BirthYear) &&
        !string.IsNullOrEmpty(IssueYear) &&
        !string.IsNullOrEmpty(ExpirationYear) &&
        !string.IsNullOrEmpty(Height) &&
        !string.IsNullOrEmpty(HairColor) &&
        !string.IsNullOrEmpty(EyeColor) &&
        !string.IsNullOrEmpty(PassportId);

    public string Height { get; set; }

    public bool IsBirthYearValid => !string.IsNullOrEmpty(BirthYear) &&
        int.TryParse(BirthYear, out var birthYear) && birthYear >= 1920 && birthYear <= 2002;

    public bool IsExpirationYearValid => !string.IsNullOrEmpty(ExpirationYear) &&
        int.TryParse(ExpirationYear, out var expirationYear) && expirationYear >= 2020 &&
        expirationYear <= 2030;

    public bool IsEyeColorValid => !string.IsNullOrEmpty(EyeColor) && ValidEyeColors.Contains(EyeColor);

    public bool IsHairColorValid =>
        !string.IsNullOrEmpty(HairColor) && Regex.IsMatch(HairColor, @"^#[0-9a-f]{6}$");

    public bool IsHeightValid => !string.IsNullOrEmpty(Height) && ValidateHeight(Height);

    public bool IsIssueYearValid => !string.IsNullOrEmpty(IssueYear) &&
        int.TryParse(IssueYear, out var issueYear) && issueYear >= 2010 && issueYear <= 2020;

    public bool IsPassportIdValid =>
        !string.IsNullOrEmpty(PassportId) && Regex.IsMatch(PassportId, @"^[0-9]{9}$");

    public string IssueYear { get; set; }

    public bool IsValid =>
        HasRequiredFields &&
        IsBirthYearValid &&
        IsIssueYearValid &&
        IsExpirationYearValid &&
        IsHeightValid &&
        IsHairColorValid &&
        IsEyeColorValid &&
        IsPassportIdValid;

    public string PassportId { get; set; }
}