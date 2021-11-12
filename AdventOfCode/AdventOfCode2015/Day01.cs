namespace AdventOfCode2015;

public class Day01 : Day<string>
{
	public override long Perform1(string inputString)
	{
		var result = 0;

		foreach (var character in inputString)
		{
			switch (character)
			{
				case '(': result++; break;
				case ')': result--; break;
			}
		}

		return result;
	}

	public override long Perform2(string inputString)
	{
		var result = 0;

		for (var i = 0; i < inputString.Length; i++)
		{
			switch (inputString[i])
			{
				case '(': result++; break;
				case ')': result--; break;
			}

			if (result == -1) return i + 1;
		}

		return 0;
	}

	protected override string ParseInput(string inputString)
	{
		return inputString;
	}
}