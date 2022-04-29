namespace AdventOfCode2021;

public class Day11 : Day<byte[,]>
{
	public override long Perform1(string inputString)
	{
		var grid = this.ParseInput(inputString);
		var flashingOctopuses = 0L;
		for (var i = 0; i < 100; i++) flashingOctopuses += PerformStep(grid);
		return flashingOctopuses;
	}

	public override long Perform2(string inputString)
	{
		var grid = this.ParseInput(inputString);
		var stepCount = 0L;
		while (true)
		{
			var allZeroes = true;
			stepCount++;
			PerformStep(grid);
			for (var i = 0; i < grid.GetLength(0); i++)
				for (var j = 0; j < grid.GetLength(1); j++)
					allZeroes &= grid[i, j] == 0;
			if (allZeroes) break;
		}
		return stepCount;
	}

	protected override byte[,] ParseInput(string inputString)
	{
		var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		var result = new byte[rows.Length, rows[0].Length];
		for (var i = 0; i < rows.Length; i++)
			for (var j = 0; j < rows[i].Length; j++)
				result[i, j] = Byte.Parse(rows[i][j].ToString());
		return result;
	}

	private static long PerformStep(byte[,] grid)
	{
		var flashingOctopuses = 0L;

		for (var i = 0; i < grid.GetLength(0); i++)
			for (var j = 0; j < grid.GetLength(1); j++)
				grid[i, j]++;

		for (var i = 0; i < grid.GetLength(0); i++)
			for (var j = 0; j < grid.GetLength(1); j++)
			{
				if (grid[i, j] <= 9) continue;
				FlashOctopus(grid, ref flashingOctopuses, i, j);
			}

		return flashingOctopuses;
	}

	private static void FlashOctopus(byte[,] grid, ref long flashingOctopuses, int i, int j)
	{
		grid[i, j] = 0;
		flashingOctopuses++;

		var iLowerBound = i == 0 ? 0 : i - 1;
		var iUpperBound = i == grid.GetLength(0) - 1 ? i : i + 1;
		var jLowerBound = j == 0 ? 0 : j - 1;
		var jUpperBound = j == grid.GetLength(1) - 1 ? j : j + 1;

		for (var x = iLowerBound; x <= iUpperBound; x++)
			for (var y = jLowerBound; y <= jUpperBound; y++)
			{
				if (grid[x, y] == 0) continue;
				grid[x, y]++;
				if (grid[x, y] <= 9) continue;
				FlashOctopus(grid, ref flashingOctopuses, x, y);
			}
	}
}
