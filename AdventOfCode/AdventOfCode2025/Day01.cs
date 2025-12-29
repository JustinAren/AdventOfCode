namespace AdventOfCode2025;

public class Day01 : Day<List<(char Operation, int Count)>>
{
    public override string Perform1(string inputString)
    {
        var input = ParseInput(inputString);
        var value = 50;
        var count = 0;

        foreach (var (operation, operationCount) in input)
        {
            value += operation == 'R' ? operationCount : -operationCount;
            value = (value % 100 + 100) % 100;
            if (value == 0) count++;
        }

        return count.ToString();
    }

    public override string Perform2(string inputString) => throw new NotImplementedException();

    protected override List<(char Operation, int Count)> ParseInput(string inputString)
        => inputString.SplitNewLine().Select(row => (row[0], int.Parse(row[1..]))).ToList();
}