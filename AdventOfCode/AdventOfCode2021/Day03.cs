using System.Text;

namespace AdventOfCode2021;

public class Day03 : Day<string[]>
{
	public override long Perform1(string inputString)
	{
		var input = this.ParseInput(inputString);
		var gammaBuilder = new StringBuilder();
		var epsilonBuilder = new StringBuilder();

		for (var i = 0; i < input[0].Length; i++)
		{
			var zeroCount = 0;
			var oneCount = 0;

			foreach (var row in input)
			{
				switch (row[i])
				{
					case '0': zeroCount++; break;
					case '1': oneCount++; break;
				}
			}

			if (zeroCount > oneCount)
			{
				gammaBuilder.Append('0');
				epsilonBuilder.Append('1');
			}
			else
			{
				gammaBuilder.Append('1');
				epsilonBuilder.Append('0');
			}
		}

		var gamma = Convert.ToInt64(gammaBuilder.ToString(), 2);
		var epsilon = Convert.ToInt64(epsilonBuilder.ToString(), 2);

		return gamma * epsilon;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override string[] ParseInput(string inputString)
	{
		var result = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		return result;
	}
}
