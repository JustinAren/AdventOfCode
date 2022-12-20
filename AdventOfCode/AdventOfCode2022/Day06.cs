using System.Text;

namespace AdventOfCode2022;

public class Day06 : Day<string>
{
	protected override string ParseInput(string inputString) => inputString;

	public override string Perform1(string inputString)
	{
		for (var i = 4; i < inputString.Length; i++)
		{
			if (inputString.Skip(i - 4).Take(4).Distinct().Count() == 4)
				return i.ToString();
		}

		return inputString.Length.ToString();
	}

	public override string Perform2(string inputString)
	{
		throw new NotImplementedException();
	}
}