﻿namespace AdventOfCode2020;

public class Day06 : Day<string[]>
{
    private static int ParseInput1(string inputString)
    {
        var result = new HashSet<char>();

        var inputs = inputString.SplitNewLine();

        foreach (var input in inputs)
        foreach (var character in input)
            result.Add(character);

        return result.Count;
    }

    private static int ParseInput2(string inputString)
    {
        var inputs = inputString.SplitNewLine();
        var dictionary = new Dictionary<char, int>();

        foreach (var input in inputs)
        foreach (var character in input)
            if (dictionary.ContainsKey(character)) dictionary[character]++;
            else dictionary.Add(character, 1);

        return dictionary.Count(kvp => kvp.Value == inputs.Length);
    }

    protected override string[] ParseInput(string inputString) =>
        inputString.Split($"{Environment.NewLine}{Environment.NewLine}",
            StringSplitOptions.RemoveEmptyEntries);

    public override string Perform1(string inputString)
    {
        var inputStrings = ParseInput(inputString);
        return inputStrings.Select(ParseInput1).Sum().ToString();
    }

    public override string Perform2(string inputString)
    {
        var inputStrings = ParseInput(inputString);
        return inputStrings.Select(ParseInput2).Sum().ToString();
    }
}