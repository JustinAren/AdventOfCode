using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day19 : Day<(Dictionary<byte, Day19Rule> RulesByNumber, string[] Messages)>
	{
		public override ulong Perform1(string inputString)
		{
			var (rulesByNumber, messages) = this.ParseInput(inputString);
			var possibleValues = rulesByNumber[0].GeneratePossibleValues(rulesByNumber);
			var matchingCount = messages.Count(message => possibleValues.Contains(message));
			return (ulong) matchingCount;
		}

		public override ulong Perform2(string inputString)
		{
			var (rulesByNumber, messages) = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override (Dictionary<byte, Day19Rule> RulesByNumber, string[] Messages) ParseInput(string inputString)
		{
			var lines = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var rulesByNumber = lines.Where(line => Char.IsDigit(line[0])).Select(ParseLine).ToDictionary(rule => rule.Number);
			var messages = lines.Where(line => Char.IsLetter(line[0])).ToArray();
			return (rulesByNumber, messages);
		}

		private static Day19Rule ParseLine(string line)
		{
			var lineSplitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			var number = Byte.Parse(lineSplitted[0]);

			if (lineSplitted[1][0] == '"') return new CharacterRule(number, lineSplitted[1].Replace(@"""", ""));
			var sequences = lineSplitted[1].Split("|", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			var firstSequence = sequences[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(Byte.Parse).ToArray();
			var secondSequence = sequences.Length == 2 ? sequences[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(Byte.Parse).ToArray() : null;
			return new SubRule(number, firstSequence, secondSequence);
		}
	}

	public abstract class Day19Rule
	{
		public override int GetHashCode() => this.Number.GetHashCode();

		public byte Number { get; }
		protected string[] PossibleValues { get; set; }

		protected Day19Rule(byte number)
		{
			this.Number = number;
		}

		public abstract string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber);
	}

	public class CharacterRule : Day19Rule
	{
		public string Character { get; }

		public CharacterRule(byte number, string character) 
			: base(number)
		{
			this.Character = character;
		}

		public override string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber)
		{
			if (this.PossibleValues is not null) return this.PossibleValues;
			this.PossibleValues = new[] {this.Character};
			return this.PossibleValues;
		}
	}

	public class SubRule : Day19Rule
	{
		public byte[] FirstSequence { get; }
		public byte[] SecondSequence { get; }

		public SubRule(byte number, byte[] firstSequence, byte[] secondSequence) 
			: base(number)
		{
			this.FirstSequence = firstSequence;
			this.SecondSequence = secondSequence;
		}

		public override string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber)
		{
			if (this.PossibleValues is not null) return this.PossibleValues;
			this.PossibleValues = ProcessSequence(this.FirstSequence, rulesByNumber).Concat(ProcessSequence(this.SecondSequence, rulesByNumber)).ToArray();
			return this.PossibleValues;
		}

		private static IEnumerable<string> ProcessSequence(byte[] sequence, Dictionary<byte, Day19Rule> rulesByNumber)
		{
			if (sequence is null) return Array.Empty<string>();

			var result = new List<string> {""};

			foreach (var number in sequence)
			{
				var possibleValuesForNumber = rulesByNumber[number].GeneratePossibleValues(rulesByNumber);
				var subResult = new List<string>();

				foreach (var s in result) subResult.AddRange(possibleValuesForNumber.Select(value => $"{s}{value}"));

				result = subResult;
			}

			return result;
		}
	}
}
