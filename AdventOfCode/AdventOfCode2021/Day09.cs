namespace AdventOfCode2021;

public class Day09 : Day<long[,]>
{
	public override long Perform1(string inputString)
	{
		var grid = this.ParseInput(inputString);
		var result = 0L;

		var iMax = grid.GetLength(0);
		var jMax = grid.GetLength(1);

		for (var i = 0; i < iMax; i++)
		{
			for (var j = 0; j < jMax; j++)
			{
				var current = grid[i, j];

				if (i > 0 && grid[i - 1, j] <= current) continue;
				if (j > 0 && grid[i, j - 1] <= current) continue;
				if (i < iMax - 1 && grid[i + 1, j] <= current) continue;
				if (j < jMax - 1 && grid[i, j + 1] <= current) continue;

				result += current + 1;
			}
		}

		return result;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override long[,] ParseInput(string inputString)
	{
		var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		var result = new long[rows.Length, rows[0].Length];
		for (var i = 0; i < rows.Length; i++)
		for (var j = 0; j < rows[i].Length; j++)
			result[i,j] = Int64.Parse(rows[i][j].ToString());
		return result;
	}
}
