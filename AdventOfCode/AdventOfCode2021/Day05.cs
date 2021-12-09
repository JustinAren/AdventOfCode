namespace AdventOfCode2021;

public class Day05 : Day<Line[]>
{
	public override long Perform1(string inputString)
	{
		var gridDictionary = new Dictionary<(int X, int Y), int>();
		var lines = this.ParseInput(inputString);
		foreach (var line in lines)
		{
			if (line.IsHorizontal)
			{
				var lowerBound = Math.Min(line.X1, line.X2);
				var upperBound = Math.Max(line.X1, line.X2);

				for (var i = lowerBound; i <= upperBound; i++)
				{
					var coordinate = (i, line.Y1);
					if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
					else gridDictionary.Add(coordinate, 1);
				}
			}
			else if (line.IsVertical)
			{
				var lowerBound = Math.Min(line.Y1, line.Y2);
				var upperBound = Math.Max(line.Y1, line.Y2);

				for (var i = lowerBound; i <= upperBound; i++)
				{
					var coordinate = (line.X1, i);
					if (gridDictionary.ContainsKey(coordinate)) gridDictionary[coordinate]++;
					else gridDictionary.Add(coordinate, 1);
				}
			}
		}

		var overlapCount = gridDictionary.Count(kvp => kvp.Value > 1);
		return overlapCount;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override Line[] ParseInput(string inputString)
	{
		var result = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Line.Parse).ToArray();
		return result;
	}
}

public readonly record struct Line(int X1, int X2, int Y1, int Y2)
{
	public bool IsHorizontal => this.Y1 == this.Y2;
	public bool IsVertical => this.X1 == this.X2;

	public static Line Parse(string line)
	{
		var parts = line.Split(" -> ");
		var x1y1 = parts[0].Split(',');
		var x2y2 = parts[1].Split(',');
		return new Line(Int32.Parse(x1y1[0]), Int32.Parse(x2y2[0]), Int32.Parse(x1y1[1]), Int32.Parse(x2y2[1]));
	}
};
