namespace AdventOfCode2025;

public class Day04 : Day<string[]>
{
    protected override string[] ParseInput(string inputString) => inputString.SplitNewLine();

    public override string Perform1(string inputString)
    {
        var rows = ParseInput(inputString);
        var result = 0;

        var rowCount = rows.Length;
        var colCount = rows[0].Length;

        for (var i = 0; i < rowCount; i++)
        {
            for (var j = 0; j < colCount; j++)
            {
                if (rows[i][j] != '@') continue;
                var count = 0;
                if (i > 0 && j > 0 && rows[i - 1][j - 1] == '@') count++;
                if (i > 0 && rows[i - 1][j] == '@') count++;
                if (i > 0 && j < colCount - 1 && rows[i - 1][j + 1] == '@') count++;
                if (j > 0 && rows[i][j - 1] == '@') count++;
                if (j < colCount - 1 && rows[i][j + 1] == '@') count++;
                if (i < rowCount - 1 && j > 0 && rows[i + 1][j - 1] == '@') count++;
                if (i < rowCount - 1 && rows[i + 1][j] == '@') count++;
                if (i < rowCount - 1 && j < colCount - 1 && rows[i + 1][j + 1] == '@') count++;
                if (count < 4) result++;
            }
        }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var rows = ParseInput(inputString);
        var result = 0;
        return result.ToString();
    }
}