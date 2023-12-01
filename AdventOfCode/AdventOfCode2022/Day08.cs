namespace AdventOfCode2022;

public class Day08 : Day<byte[,]>
{
    protected override byte[,] ParseInput(string inputString)
    {
        var lines = inputString.SplitNewLine();
        var result = new byte[lines[0].Length, lines.Length];

        for (var i = 0; i < lines[0].Length; i++)
        for (var j = 0; j < lines.Length; j++)
            result[i, j] = byte.Parse(lines[i][j].ToString());

        return result;
    }

    public override string Perform1(string inputString)
    {
        var grid = ParseInput(inputString);
        var visibleTrees = new HashSet<(int, int)>();

        var rowCount = grid.GetLength(0);
        var columnCount = grid.GetLength(1);

        for (var i = 0; i < rowCount; i++)
        {
            var longest = -1;
            for (var j = 0; j < columnCount; j++)
            {
                if (grid[i, j] > longest)
                {
                    longest = grid[i, j];
                    visibleTrees.Add((i, j));
                }

                if (longest == 9) break;
            }
        }

        for (var j = 0; j < columnCount; j++)
        {
            var longest = -1;
            for (var i = 0; i < rowCount; i++)
            {
                if (grid[i, j] > longest)
                {
                    longest = grid[i, j];
                    visibleTrees.Add((i, j));
                }

                if (longest == 9) break;
            }
        }

        for (var i = rowCount - 1; i >= 0; i--)
        {
            var longest = -1;
            for (var j = columnCount - 1; j >= 0; j--)
            {
                if (grid[i, j] > longest)
                {
                    longest = grid[i, j];
                    visibleTrees.Add((i, j));
                }

                if (longest == 9) break;
            }
        }

        for (var j = columnCount - 1; j >= 0; j--)
        {
            var longest = -1;
            for (var i = rowCount - 1; i >= 0; i--)
            {
                if (grid[i, j] > longest)
                {
                    longest = grid[i, j];
                    visibleTrees.Add((i, j));
                }

                if (longest == 9) break;
            }
        }

        return visibleTrees.Count.ToString();
    }

    public override string Perform2(string inputString)
    {
        var grid = ParseInput(inputString);
        var highestScore = 0;

        var rowCount = grid.GetLength(0);
        var columnCount = grid.GetLength(1);

        for (var i = 0; i < rowCount; i++)
        for (var j = 0; j < columnCount; j++)
        {
            var top = 0;
            var bottom = 0;
            var left = 0;
            var right = 0;
            var height = grid[i, j];

            for (var k = i - 1; k >= 0; k--)
            {
                top++;
                if (grid[k, j] >= height) break;
            }

            for (var k = i + 1; k < rowCount; k++)
            {
                bottom++;
                if (grid[k, j] >= height) break;
            }

            for (var k = j - 1; k >= 0; k--)
            {
                left++;
                if (grid[i, k] >= height) break;
            }

            for (var k = j + 1; k < columnCount; k++)
            {
                right++;
                if (grid[i, k] >= height) break;
            }

            var score = top * bottom * left * right;
            if (score > highestScore) highestScore = score;
        }

        return highestScore.ToString();
    }
}