namespace AdventOfCode2022;

public class Day06 : Day<string>
{
	protected override string ParseInput(string inputString) => inputString;

	public override string Perform1(string inputString) => GetStartOfPackagePosition(inputString, 4);

	public override string Perform2(string inputString) => GetStartOfPackagePosition(inputString, 14);

	private static string GetStartOfPackagePosition(string inputString, int uniquenessCount)
	{
		for (var i = uniquenessCount; i < inputString.Length; i++)
		{
			if (inputString.Skip(i - uniquenessCount).Take(uniquenessCount).Distinct().Count() == uniquenessCount)
				return i.ToString();
		}

		return inputString.Length.ToString();
	}
}