using System.Text;

namespace AdventOfCode2021;

public class Day08 : Day<Pattern[]>
{
    private static readonly int[] EasyLengths = { 2, 3, 4, 7 };

    protected override Pattern[] ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Pattern.Parse).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var patterns = ParseInput(inputString);
        var result = patterns.SelectMany(pattern => pattern.OutputSignals)
            .Count(signal => EasyLengths.Contains(signal.Length));
        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var patterns = ParseInput(inputString);
        var result = patterns.Sum(pattern => pattern.CalculateOutputSignal());
        return result.ToString();
    }
}

public readonly record struct Pattern(string[] InputSignals, string[] OutputSignals)
{
    public static Pattern Parse(string input)
    {
        var splits = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
        var result = new Pattern(splits[0].Split(' ', StringSplitOptions.RemoveEmptyEntries),
            splits[1].Split(' ', StringSplitOptions.RemoveEmptyEntries));
        return result;
    }

    public long CalculateOutputSignal()
    {
        var inputSignalList =
            InputSignals.Select(signal => new string(signal.OrderBy(c => c).ToArray())).ToList();
        var numbers = new Dictionary<int, string>
        {
            [1] = inputSignalList.Single(signal => signal.Length == 2),
            [4] = inputSignalList.Single(signal => signal.Length == 4),
            [7] = inputSignalList.Single(signal => signal.Length == 3),
            [8] = inputSignalList.Single(signal => signal.Length == 7),
        };

        inputSignalList.Remove(numbers[1]);
        ;
        inputSignalList.Remove(numbers[4]);
        inputSignalList.Remove(numbers[7]);
        inputSignalList.Remove(numbers[8]);

        numbers[9] = inputSignalList.Single(signal => signal.Length == 6 && Contains(signal, numbers[4]));
        inputSignalList.Remove(numbers[9]);
        numbers[3] = inputSignalList.Single(signal => signal.Length == 5 && Contains(signal, numbers[1]));
        inputSignalList.Remove(numbers[3]);
        numbers[0] = inputSignalList.Single(signal => signal.Length == 6 && Contains(signal, numbers[1]));
        inputSignalList.Remove(numbers[0]);
        numbers[6] = inputSignalList.Single(signal => signal.Length == 6);
        inputSignalList.Remove(numbers[6]);
        numbers[5] = inputSignalList.Single(signal => signal.Length == 5 && Contains(numbers[6], signal));
        inputSignalList.Remove(numbers[5]);
        numbers[2] = inputSignalList.Single(signal => signal.Length == 5);
        inputSignalList.Remove(numbers[2]);

        var outputBuilderDictionary = numbers.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        var outputBuilder = new StringBuilder();
        foreach (var outputSignal in OutputSignals.Select(
                     signal => new string(signal.OrderBy(c => c).ToArray())))
            outputBuilder.Append(outputBuilderDictionary[outputSignal]);
        var result = long.Parse(outputBuilder.ToString());
        return result;

        static bool Contains(string original, string substring) =>
            substring.All(c => original.IndexOf(c) != -1);
    }
}