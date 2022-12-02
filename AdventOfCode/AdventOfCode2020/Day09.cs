namespace AdventOfCode2020;

public class Day09 : Day<long[]>
{
    private static long GetInvalidEntry(IReadOnlyList<long> inputArray)
    {
        var preamble = inputArray.Count > 25 ? 25 : 5;

        for (var i = preamble; i < inputArray.Count; i++)
        {
            var previousDigits = inputArray.Skip(i - preamble).Take(preamble).ToArray();
            if (!IsValid(inputArray[i], previousDigits)) return inputArray[i];
        }

        return 0;
    }

    private static bool IsValid(long controlDigit, IReadOnlyList<long> previousDigits)
    {
        for (var i = 0; i < previousDigits.Count; i++)
        {
            for (var j = i + 1; j < previousDigits.Count; j++)
            {
                if (previousDigits[i] + previousDigits[j] == controlDigit) return true;
            }
        }

        return false;
    }

    protected override long[] ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToArray();
    }

    public override long Perform1(string inputString)
    {
        var inputArray = ParseInput(inputString);
        return GetInvalidEntry(inputArray);
    }

    public override long Perform2(string inputString)
    {
        var inputArray = ParseInput(inputString);
        var invalidValue = GetInvalidEntry(inputArray);

        for (var i = 0; i < inputArray.Length; i++)
        {
            for (var j = i + 1; j < inputArray.Length; j++)
            {
                if (i == j) continue;
                var numbers = inputArray.Skip(i).Take(j - i).ToArray();
                if (numbers.Sum(n => n) == invalidValue) return numbers.Min() + numbers.Max();
            }
        }

        return 0;
    }
}