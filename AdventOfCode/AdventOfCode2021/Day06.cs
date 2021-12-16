namespace AdventOfCode2021;

public class Day06 : Day<List<int>>
{
	public override long Perform1(string inputString)
	{
		var fishCounters = this.ParseInput(inputString);

		for (var i = 0; i < 80; i++) fishCounters = ProcessDay(fishCounters);

		return fishCounters.Count;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override List<int> ParseInput(string inputString)
	{
		return inputString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
	}

	private static List<int> ProcessDay(List<int> fishCounterList)
	{
		var resultList = new List<int>();
		foreach (var fishCounter in fishCounterList)
		{
			if (fishCounter == 0)
			{
				resultList.Add(6);
				resultList.Add(8);
			}
			else
			{
				resultList.Add(fishCounter - 1);
			}
		}

		return resultList;
	}
}
