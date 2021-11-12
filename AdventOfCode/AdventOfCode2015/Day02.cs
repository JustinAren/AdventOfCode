namespace AdventOfCode2015;

public class Day02 : Day<Present[]>
{
	public override long Perform1(string inputString)
	{
		var inputRectangles = this.ParseInput(inputString);
		var result = inputRectangles.Select(present => present.CalculateWrappingPaperSurface()).Sum();
		return result;
	}

	public override long Perform2(string inputString)
	{
		var inputRectangles = this.ParseInput(inputString);
		var result = inputRectangles.Select(present => present.CalculateRibbonLength()).Sum();
		return result;
	}

	protected override Present[] ParseInput(string inputString)
	{
		var strings = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		var result = new Present[strings.Length];
		for (var i = 0; i < strings.Length; i++)
		{
			var splits = strings[i].Split('x', StringSplitOptions.RemoveEmptyEntries);
			result[i] = new Present(Int32.Parse(splits[0]), Int32.Parse(splits[1]), Int32.Parse(splits[2]));
		}

		return result;
	}
}

public readonly record struct Present(int Length, int Width, int Height)
{
	public int CalculateWrappingPaperSurface()
	{
		var lwSurface = this.Length * this.Width;
		var whSurface = this.Width * this.Height;
		var lhSurface = this.Length * this.Height;
		var minSurface = Math.Min(Math.Min(lwSurface, whSurface), lhSurface);
		return 2 * lwSurface + 2 * whSurface + 2 * lhSurface + minSurface;
	}

	public int CalculateRibbonLength()
	{
		var bowLength = this.Length * this.Width * this.Height;
		var dimensionOrdered = new[] { this.Length, this.Width, this.Height }.OrderBy(d => d).ToArray();
		var min1 = dimensionOrdered[0];
		var min2 = dimensionOrdered[1];
		return 2 * min1 + 2 * min2 + bowLength;
	}
}