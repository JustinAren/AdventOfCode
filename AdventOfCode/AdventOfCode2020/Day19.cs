namespace AdventOfCode2020;

public class Day19 : Day<(Dictionary<byte, Day19Rule> RulesByNumber, string[] Messages)>
{
    private static Day19Rule ParseLine(string line)
    {
        var lineSplitted =
            line.Split(":", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var number = byte.Parse(lineSplitted[0]);

        if (lineSplitted[1][0] == '"') return new CharacterRule(number, lineSplitted[1].Replace(@"""", ""));
        var sequences = lineSplitted[1]
            .Split("|", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var firstSequence = sequences[0]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(byte.Parse).ToArray();

        var secondSequence = sequences.Length == 2
            ? sequences[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(byte.Parse).ToArray()
            : null;

        return new SubRule(number, firstSequence, secondSequence);
    }

    protected override (Dictionary<byte, Day19Rule> RulesByNumber, string[] Messages) ParseInput(
        string inputString)
    {
        var lines = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var rulesByNumber = lines.Where(line => char.IsDigit(line[0])).Select(ParseLine)
            .ToDictionary(rule => rule.Number);

        var messages = lines.Where(line => char.IsLetter(line[0])).ToArray();
        return (rulesByNumber, messages);
    }

    public override string Perform1(string inputString)
    {
        var (rulesByNumber, messages) = ParseInput(inputString);
        var possibleValues = rulesByNumber[0].GeneratePossibleValues(rulesByNumber);
        var matchingCount = messages.Count(message => possibleValues.Contains(message));
        return matchingCount.ToString();
    }

    public override string Perform2(string inputString) => throw new NotImplementedException();
}

public abstract class Day19Rule
{
    protected Day19Rule(byte number) => Number = number;

    public abstract string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber);

    protected string[] PossibleValues { get; set; }

    public byte Number { get; }
}

public class CharacterRule : Day19Rule
{
    public CharacterRule(byte number, string character)
        : base(number) =>
        Character = character;

    public override string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber)
    {
        if (PossibleValues is not null) return PossibleValues;
        PossibleValues = new[] { Character };
        return PossibleValues;
    }

    private string Character { get; }
}

public class SubRule : Day19Rule
{
    public SubRule(byte number, byte[] firstSequence, byte[] secondSequence)
        : base(number)
    {
        FirstSequence = firstSequence;
        SecondSequence = secondSequence;
    }

    private static IEnumerable<string> ProcessSequence(byte[] sequence,
        Dictionary<byte, Day19Rule> rulesByNumber)
    {
        if (sequence is null) return Array.Empty<string>();

        var result = new List<string> { "" };

        foreach (var number in sequence)
        {
            var possibleValuesForNumber = rulesByNumber[number].GeneratePossibleValues(rulesByNumber);
            var subResult = new List<string>();

            foreach (var s in result)
                subResult.AddRange(possibleValuesForNumber.Select(value => $"{s}{value}"));

            result = subResult;
        }

        return result;
    }

    public override string[] GeneratePossibleValues(Dictionary<byte, Day19Rule> rulesByNumber)
    {
        if (PossibleValues is not null) return PossibleValues;
        PossibleValues = ProcessSequence(FirstSequence, rulesByNumber)
            .Concat(ProcessSequence(SecondSequence, rulesByNumber)).ToArray();

        return PossibleValues;
    }

    private byte[] FirstSequence { get; }

    private byte[] SecondSequence { get; }
}