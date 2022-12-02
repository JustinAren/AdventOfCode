namespace AdventOfCode2020;

public class Day16 : Day<(Day16Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets)>
{
    protected override (Day16Rule[] Rules, Ticket MyTicket, Ticket[] NearbyTickets) ParseInput(
        string inputString)
    {
        var input = inputString.Split($"{Environment.NewLine}{Environment.NewLine}",
            StringSplitOptions.RemoveEmptyEntries);
        var ruleStrings = input[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var myTicketString = input[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1];
        var nearbyTicketStrings =
            input[2].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1);
        return (ruleStrings.Select(Day16Rule.Parse).ToArray(), Ticket.Parse(myTicketString),
            nearbyTicketStrings.Select(Ticket.Parse).ToArray());
    }

    public override long Perform1(string inputString)
    {
        var (rules, _, nearbyTickets) = ParseInput(inputString);
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
        var (rules, myTicket, nearbyTickets) = ParseInput(inputString);
        var validTickets = nearbyTickets.Where(ticket => ticket.ValidateAgainstRules(rules, out _)).ToArray();

        var possibleColumnsPerRule = new Dictionary<string, List<int>>();

        foreach (var rule in rules)
        {
            for (var i = 0; i < rules.Length; i++)
            {
                if (!validTickets.Select(ticket => ticket.Values[i])
                        .All(value => rule.ValidateValue(value))) continue;

                if (possibleColumnsPerRule.ContainsKey(rule.Name)) possibleColumnsPerRule[rule.Name].Add(i);
                else possibleColumnsPerRule.Add(rule.Name, new List<int> { i });
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
}

public class Day16Rule
{
    public Day16Rule(string name, (long Min, long Max) range1, (long Min, long Max) range2)
    {
        Name = name;
        Range1 = range1;
        Range2 = range2;
    }

    private static (long Min, long Max) ParseRange(string rangeString)
    {
        var range = rangeString.Split('-', StringSplitOptions.RemoveEmptyEntries);
        return (long.Parse(range[0]), long.Parse(range[1]));
    }

    public static Day16Rule Parse(string inputString)
    {
        var inputs = inputString.Split(':', StringSplitOptions.RemoveEmptyEntries);
        var ranges = inputs[1].Split("or", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
            .Select(ParseRange).ToArray();
        return new Day16Rule(inputs[0], ranges[0], ranges[1]);
    }

    public bool ValidateValue(long value)
    {
        return (value >= Range1.Min && value <= Range1.Max) ||
            (value >= Range2.Min && value <= Range2.Max);
    }

    public string Name { get; }

    public (long Min, long Max) Range1 { get; }

    public (long Min, long Max) Range2 { get; }
}

public class Ticket
{
    public Ticket(long[] values)
    {
        Values = values;
    }

    public static Ticket Parse(string inputString)
    {
        return new(inputString.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray());
    }

    public bool ValidateAgainstRules(Day16Rule[] rules, out IReadOnlyCollection<long> invalidValues)
    {
        invalidValues = Values.Where(value => !rules.Any(rule => rule.ValidateValue(value))).ToArray();
        return !invalidValues.Any();
    }

    public long[] Values { get; }
}