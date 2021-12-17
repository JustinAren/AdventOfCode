namespace AdventOfCode2021;

public class Day08 : Day<Pattern[]>
{
	public override long Perform1(string inputString)
	{
		throw new NotImplementedException();
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

	}
}
