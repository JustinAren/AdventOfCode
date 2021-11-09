﻿using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day16 : Day<(Day16Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets)>
	{
		public override long Perform1(string inputString)
		{
			var (rules, _, nearbyTickets) = this.ParseInput(inputString);
			var invalidValues = new List<long>();

			foreach (var ticket in nearbyTickets)
			{
				if (ticket.ValidateAgainstRules(rules, out var invalids)) continue;
				invalidValues.AddRange(invalids);
			}

			return (long)invalidValues.Sum(v => (decimal)v);
		}

		public override long Perform2(string inputString)
		{
			var (rules, myTicket, nearbyTickets) = this.ParseInput(inputString);
			var validTickets = nearbyTickets.Where(ticket => ticket.ValidateAgainstRules(rules, out _)).ToArray();

			var possibleColumnsPerRule = new Dictionary<string, List<int>>();

			foreach (var rule in rules)
			{
				for (var i = 0; i < rules.Length; i++)
				{
					if (!validTickets.Select(ticket => ticket.Values[i]).All(value => rule.ValidateValue(value))) continue;

					if (possibleColumnsPerRule.ContainsKey(rule.Name)) possibleColumnsPerRule[rule.Name].Add(i);
					else possibleColumnsPerRule.Add(rule.Name, new List<int> {i});
				}
			}

			var actualColumnForRule = new Dictionary<string, int>();

			foreach (var (name, columns) in possibleColumnsPerRule.OrderBy(kvp => kvp.Value.Count))
			{
				var actualColumns = columns.Except(actualColumnForRule.Values).ToArray();
				if (actualColumns.Length == 1) actualColumnForRule.Add(name, actualColumns[0]);
			}

			return actualColumnForRule
				.Where(kvp => kvp.Key.StartsWith("departure"))
				.Select(kvp => kvp.Value)
				.Aggregate<int, long>(1, (current, column) => current * myTicket.Values[column]);
		}

		protected override (Day16Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets) ParseInput(string inputString)
		{
			var input = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
			var ruleStrings = input[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var myTicketString = input[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1];
			var nearbyTicketStrings = input[2].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1);
			return (ruleStrings.Select(Day16Rule.Parse).ToArray(), Ticket.Parse(myTicketString), nearbyTicketStrings.Select(Ticket.Parse).ToArray());
		}
	}

	public class Day16Rule
	{
		public string Name { get; }
		public (long Min, long Max) Range1 { get; }
		public (long Min, long Max) Range2 { get; }

		public Day16Rule(string name, (long Min, long Max) range1, (long Min, long Max) range2)
		{
			this.Name = name;
			this.Range1 = range1;
			this.Range2 = range2;
		}

		public bool ValidateValue(long value)
		{
			return value >= this.Range1.Min && value <= this.Range1.Max ||
				   value >= this.Range2.Min && value <= this.Range2.Max;
		}

		public static Day16Rule Parse(string inputString)
		{
			var inputs = inputString.Split(':', StringSplitOptions.RemoveEmptyEntries);
			var ranges = inputs[1].Split("or", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).Select(ParseRange).ToArray();
			return new Day16Rule(inputs[0], ranges[0], ranges[1]);
		}

		private static (long Min, long Max) ParseRange(string rangeString)
		{
			var range = rangeString.Split('-', StringSplitOptions.RemoveEmptyEntries);
			return (Int64.Parse(range[0]), Int64.Parse(range[1]));
		}
	}

	public class Ticket
	{
		public long[] Values { get; }

		public Ticket(long[] values)
		{
			this.Values = values;
		}

		public bool ValidateAgainstRules(Day16Rule[] rules, out IReadOnlyCollection<long> invalidValues)
		{
			invalidValues = this.Values.Where(value => !rules.Any(rule => rule.ValidateValue(value))).ToArray();
			return !invalidValues.Any();
		}

		public static Ticket Parse(string inputString)
		{
			return new(inputString.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int64.Parse).ToArray());
		}
	}
}
