namespace AdventOfCode2020;

public class Day10 : Day<List<int>>
{
    private readonly Dictionary<int, long> _values = new();

    private long Combinations(int curValue, IEnumerable<int> input)
    {
        if (!input.Any()) return 1;
        if (_values.ContainsKey(curValue)) return _values[curValue];
        _values[curValue] = input.TakeWhile(x => x > curValue && x <= curValue + 3)
            .Select((x, idx) => Combinations(x, input.Skip(idx + 1))).Sum();
        return _values[curValue];
    }

    protected override List<int> ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .OrderBy(i => i).ToList();
    }

    public override string Perform1(string inputString)
    {
        var inputList = ParseInput(inputString);
        var maxValue = inputList.Last() + 3;
        inputList.Insert(0, 0);
        inputList.Add(maxValue);

        var resultDictionary = new Dictionary<int, int>
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
        };

        for (var i = 1; i < inputList.Count; i++) resultDictionary[inputList[i] - inputList[i - 1]]++;

        return (resultDictionary[1] * resultDictionary[3]).ToString();
    }

    public override string Perform2(string inputString)
    {
        var inputList = ParseInput(inputString);
        return Combinations(0, inputList).ToString();
    }
}