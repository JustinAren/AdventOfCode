namespace AdventOfCode2021;

public class Day08 : Day<Pattern[]>
{
	private static readonly int[] EasyLengths = { 2, 3, 4, 7 };

	public override long Perform1(string inputString)
	{
		var patterns = this.ParseInput(inputString);
		var result = patterns.SelectMany(pattern => pattern.OutputSignals).Count(signal => EasyLengths.Contains(signal.Length));
		return result;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override Pattern[] ParseInput(string inputString)
	{
		return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Pattern.Parse).ToArray();
	}
}

public readonly record struct Signal(string Value)
{
	public int Length => this.Value.Length;
}

public readonly record struct Pattern(Signal[] InputSignals, Signal[] OutputSignals)
{
	public static Pattern Parse(string input)
	{
		var splits = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
		var result = new Pattern(ParseSignals(splits[0]), ParseSignals(splits[1]));
		return result;

		static Signal[] ParseSignals(string split) => split.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => new Signal(s)).ToArray();
	}
}
