using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2015
{
	public class Day05 : Day<IEnumerable<Name>>
	{
		public override long Perform1(string inputString)
		{
			var names = this.ParseInput(inputString);
			return names.Count(name => name.IsNice);
		}

		public override long Perform2(string inputString)
		{
			var names = this.ParseInput(inputString);
			throw new System.NotImplementedException();
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

		public bool IsNice => !this.HasForbiddenStrings && this.HasDoubleCharacters && this.VowelCount > 2;
		public bool IsNaughty => !this.IsNice;

		private int VowelCount => this.Value.Count(s => Vowels.Contains(s));
		private bool HasForbiddenStrings => Forbidden.Any(s => this.Value.Contains(s));
		private bool HasDoubleCharacters => Doubles.Any(s => this.Value.Contains(s));
	}
}
