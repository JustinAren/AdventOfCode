namespace AdventOfCode2025;

public class Day01 : Day<List<(char Operation, int Count)>>
{
    public override string Perform1(string inputString)
    {
        var input = ParseInput(inputString);
        var dial = 50;
        var result = 0;

        foreach (var (operation, count) in input)
        {
            dial += operation == 'R' ? count : -count;
            dial = (dial % 100 + 100) % 100;
            if (dial == 0) result++;
        }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var input = ParseInput(inputString);
        var dial = 50;
        var result = 0;

        foreach (var (operation, count) in input)
        {
            var previous = dial;
            dial += operation == 'R' ? count : -count;
            dial = (dial % 100 + 100) % 100;
            result += count / 100;
            
            if (dial == 0
                || previous != 0 && operation == 'L' && previous < dial
                || previous != 0 && operation == 'R' && previous > dial) result++;
        }

        return result.ToString();
    }

    protected override List<(char Operation, int Count)> ParseInput(string inputString)
        => inputString.SplitNewLine().Select(row => (row[0], int.Parse(row[1..]))).ToList();
}