namespace AdventOfCode2020;

public class Day05 : Day<IEnumerable<int>>
{
    private static readonly int[] Columns = Enumerable.Range(0, 8).ToArray();
    private static readonly int[] Rows = Enumerable.Range(0, 128).ToArray();

    private static int[] GetHalfOfArray(IReadOnlyCollection<int> inputArray, bool getLowerHalf)
    {
        var half = inputArray.Count / 2;
        return (getLowerHalf ? inputArray.Take(half) : inputArray.TakeLast(half)).ToArray();
    }

    private static int[] ParseCharacter(int[] inputArray, char character)
    {
        return character switch
        {
            'F' or 'L' => GetHalfOfArray(inputArray, true),
            'B' or 'R' => GetHalfOfArray(inputArray, false),
            _ => inputArray
        };
    }

    private static (int Row, int Column) ParseString(string inputString)
    {
        var rows = Rows;
        var columns = Columns;

        foreach (var character in inputString)
            switch (character)
            {
                case 'F':
                case 'B':
                    rows = ParseCharacter(rows, character);
                    break;

                case 'L':
                case 'R':
                    columns = ParseCharacter(columns, character);
                    break;
            }

        return (rows.Single(), columns.Single());
    }

    public static int CalculateSeatId(string inputString)
    {
        var (row, column) = ParseString(inputString);
        return (row * 8) + column;
    }

    protected override IEnumerable<int> ParseInput(string inputString) =>
        inputString.SplitNewLine().Select(CalculateSeatId);

    public override string Perform1(string inputString) => ParseInput(inputString).Max().ToString();

    public override string Perform2(string inputString)
    {
        var seatIds = ParseInput(inputString).OrderBy(line => line).ToArray();
        var result = 0;
        for (var i = 1; i < seatIds.Length; i++)
        {
            if (seatIds[i] - seatIds[i - 1] != 2) continue;

            result = seatIds[i] - 1;
            break;
        }

        return result.ToString();
    }
}