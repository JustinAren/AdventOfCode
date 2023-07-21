using System.Text.RegularExpressions;

namespace AdventOfCode2015;

public class Day05 : Day<IEnumerable<Name>>
{
    protected override IEnumerable<Name> ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(name => new Name(name));
    }

    public override string Perform1(string inputString)
    {
        var names = ParseInput(inputString);
        return names.Count(name => name.IsNice1).ToString();
    }

    public override string Perform2(string inputString)
    {
        var names = ParseInput(inputString);
        return names.Count(name => name.IsNice2).ToString();
    }
}

public record Name(string Value)
{
    private static readonly string[] Doubles =
    {
        "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq",
        "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
    };

    private static readonly string[] Forbidden = { "ab", "cd", "pq", "xy" };
    private static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

    private bool HasDuplicatePairs()
    {
        for (var i = 0; i < Value.Length - 1; i++)
        {
            var current = Value[i];
            var next = Value[i + 1];
            var pair = new string(new[] { current, next });
            var regex = new Regex(pair, RegexOptions.Compiled);
            if (regex.IsMatch(Value, i + 2)) return true;
        }

        return false;
    }

    private bool HasRepeatingCharacters()
    {
        for (var i = 0; i < Value.Length - 1; i++)
        {
            var current = Value[i];
            var regex = new Regex($@"{current}.{current}", RegexOptions.Compiled);
            if (regex.IsMatch(Value)) return true;
        }

        return false;
    }

    private bool HasDoubleCharacters => Doubles.Any(Value.Contains);

    private bool HasForbiddenStrings => Forbidden.Any(Value.Contains);

    private int VowelCount => Value.Count(vowel => Vowels.Contains(vowel));

    public bool IsNice1 => !HasForbiddenStrings && HasDoubleCharacters && VowelCount > 2;

    public bool IsNice2 => HasDuplicatePairs() && HasRepeatingCharacters();
}