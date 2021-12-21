namespace AdventOfCode2021;

public class Day09 : Day<LowPoint[,]>
{
	public override long Perform1(string inputString)
	{
		var grid = this.ParseInput(inputString);
		var lowPoints = GetLowPoints(grid).ToArray();
		return lowPoints.Sum(lowPoint => lowPoint.Value) + lowPoints.Length;
	}

	public override long Perform2(string inputString)
	{
		var grid = this.ParseInput(inputString);
		var lowPoints = GetLowPoints(grid);
		var basins = lowPoints.Select(lowPoint => GetBasin(lowPoint, grid, new List<LowPoint>()));
		return basins.OrderByDescending(basin => basin.Count()).Take(3).Aggregate(1L, (l, basin) => l * basin.Count());
	}

	private static IEnumerable<LowPoint> GetBasin(LowPoint current, LowPoint[,] grid, ICollection<LowPoint> basin)
	{
		while (!basin.Contains(current))
		{
			if (current.Value == 9) break;

			basin.Add(current);

			if (current.X > 0)
			{
				var adjacent = grid[current.X - 1, current.Y];
				if (current.Value < adjacent.Value) GetBasin(adjacent, grid, basin);
			}

			if (current.Y > 0)
			{
				var adjacent = grid[current.X, current.Y - 1];
				if (current.Value < adjacent.Value) GetBasin(adjacent, grid, basin);
			}

			if (current.X < grid.GetLength(0) - 1)
			{
				var adjacent = grid[current.X + 1, current.Y];
				if (current.Value < adjacent.Value) GetBasin(adjacent, grid, basin);
			}

			if (current.Y < grid.GetLength(1) - 1)
			{
				var adjacent = grid[current.X, current.Y + 1];
				if (current.Value < adjacent.Value) GetBasin(adjacent, grid, basin);
			}
		}

		return basin;
	}

	private static IEnumerable<LowPoint> GetLowPoints(LowPoint[,] grid)
	{
		var result = new List<LowPoint>();
		var iMax = grid.GetLength(0);
		var jMax = grid.GetLength(1);

		for (var i = 0; i < iMax; i++)
		{
			for (var j = 0; j < jMax; j++)
			{
				var current = grid[i, j];

				if (i > 0 && grid[i - 1, j].Value <= current.Value) continue;
				if (j > 0 && grid[i, j - 1].Value <= current.Value) continue;
				if (i < iMax - 1 && grid[i + 1, j].Value <= current.Value) continue;
				if (j < jMax - 1 && grid[i, j + 1].Value <= current.Value) continue;

				result.Add(current);
			}
		}

		return result;
	}

	protected override LowPoint[,] ParseInput(string inputString)
	{
		var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		var result = new LowPoint[rows.Length, rows[0].Length];
		for (var i = 0; i < rows.Length; i++)
			for (var j = 0; j < rows[i].Length; j++)
				result[i, j] = new LowPoint(i, j, Int64.Parse(rows[i][j].ToString()));
		return result;
	}
}

public readonly record struct LowPoint(long X, long Y, long Value);
