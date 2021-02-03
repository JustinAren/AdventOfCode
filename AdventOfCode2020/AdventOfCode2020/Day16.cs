using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day16 : Day<(Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets)>
	{
		public override ulong Perform1(string inputString)
		{
			var (rules, _, nearbyTickets) = this.ParseInput(inputString);
			var invalidValues = new List<ulong>();

			foreach (var ticket in nearbyTickets)
			{
				if (ticket.ValidateAgainstRules(rules, out var invalids)) continue;
				invalidValues.AddRange(invalids);
			}

			return (ulong)invalidValues.Sum(v => (decimal)v);
		}

		public override ulong Perform2(string inputString)
		{
			var (rules, myTicket, nearbyTickets) = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override (Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets) ParseInput(string inputString)
		{
			var input = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			var ruleStrings = input[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var myTicketString = input[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1];
			var nearbyTicketStrings = input[2].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1);
			return (ruleStrings.Select(Rule.Parse).ToArray(), Ticket.Parse(myTicketString), nearbyTicketStrings.Select(Ticket.Parse).ToArray());
		}
	}

	public class Rule
	{
		public string Name { get; }
		public (ulong Min, ulong Max) Range1 { get; }
		public (ulong Min, ulong Max) Range2 { get; }

		public Rule(string name, (ulong Min, ulong Max) range1, (ulong Min, ulong Max) range2)
		{
			this.Name = name;
			this.Range1 = range1;
			this.Range2 = range2;
		}

		public bool ValidateValue(ulong value)
		{
			return value >= this.Range1.Min && value <= this.Range1.Max ||
				   value >= this.Range2.Min && value <= this.Range2.Max;
		}

		public static Rule Parse(string inputString)
		{
			var inputs = inputString.Split(':', StringSplitOptions.RemoveEmptyEntries);
			var ranges = inputs[1].Split("or", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).Select(ParseRange).ToArray();
			return new Rule(inputs[0], ranges[0], ranges[1]);
		}

		private static (ulong Min, ulong Max) ParseRange(string rangeString)
		{
			var range = rangeString.Split('-', StringSplitOptions.RemoveEmptyEntries);
			return (UInt64.Parse(range[0]), UInt64.Parse(range[1]));
		}
	}

	public class Ticket
	{
		public IReadOnlyCollection<ulong> Values { get; }

		public Ticket(IReadOnlyCollection<ulong> values)
		{
			this.Values = values;
		}

		public bool ValidateAgainstRules(Rule[] rules, out IReadOnlyCollection<ulong> invalidValues)
		{
			invalidValues = this.Values.Where(value => !rules.Any(rule => rule.ValidateValue(value))).ToArray();
			return !invalidValues.Any();
		}

		public static Ticket Parse(string inputString)
		{
			return new(inputString.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(UInt64.Parse).ToArray());
		}
	}
}
