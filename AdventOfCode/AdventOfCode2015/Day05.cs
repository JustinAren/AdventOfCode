using System.Text.RegularExpressions;

namespace AdventOfCode2015;

public class Day05 : Day<IEnumerable<Name>>
{
	public override long Perform1(string inputString)
	{
		var names = this.ParseInput(inputString);
		return names.Count(name => name.IsNice1);
	}

	public override long Perform2(string inputString)
	{
		var names = this.ParseInput(inputString);
		return names.Count(name => name.IsNice2);
	}

	protected override IEnumerable<Name> ParseInput(string inputString)
	{
		return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(name => new Name(name));
	}
}

public record Name(string Value)
{
	private static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };
	private static readonly string[] Forbidden = { "ab", "cd", "pq", "xy" };
	private static readonly string[] Doubles = { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz" };

	private int VowelCount => this.Value.Count(s => Vowels.Contains(s));
	private bool HasForbiddenStrings => Forbidden.Any(s => this.Value.Contains(s));
	private bool HasDoubleCharacters => Doubles.Any(s => this.Value.Contains(s));

	public bool IsNice1 => !this.HasForbiddenStrings && this.HasDoubleCharacters && this.VowelCount > 2;

	public bool IsNice2 => this.HasDuplicatePairs() && this.HasRepeatingCharacters();

	private bool HasDuplicatePairs()
	{
		for (var i = 0; i < this.Value.Length - 1; i++)
		{
			var current = this.Value[i];
			var next = this.Value[i + 1];
			var pair = new string(new[] { current, next });
			var regex = new Regex(pair, RegexOptions.Compiled);
			if (regex.IsMatch(this.Value, i + 2)) return true;
		}

		return false;
	}

	private bool HasRepeatingCharacters()
	{
		for (var i = 0; i < this.Value.Length - 1; i++)
		{
			var current = this.Value[i];
			var regex = new Regex($@"{current}.{current}", RegexOptions.Compiled);
			if (regex.IsMatch(this.Value)) return true;
		}

		return false;
	}
}