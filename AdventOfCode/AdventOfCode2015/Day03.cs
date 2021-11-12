namespace AdventOfCode2015;

public class Day03 : Day<string>
{
	public override long Perform1(string inputString)
	{
		var operations = this.ParseInput(inputString);
		(int X, int Y) currentPosition = (0, 0);
		var resultSet = new HashSet<(int X, int Y)>() { currentPosition };
		foreach (var operation in operations)
		{
			currentPosition = PerformOperation(operation, currentPosition);
			resultSet.Add(currentPosition);
		}
		return resultSet.Count;
	}

	public override long Perform2(string inputString)
	{
		var operations = this.ParseInput(inputString);
		(int X, int Y) santaPosition = (0, 0);
		(int X, int Y) roboPosition = (0, 0);
		var resultSet = new HashSet<(int X, int Y)>() { santaPosition, roboPosition };
		for (var i = 0; i < operations.Length; i++)
		{
			if (i % 2 == 0)
			{
				santaPosition = PerformOperation(operations[i], santaPosition);
				resultSet.Add(santaPosition);
			}
			else
			{
				roboPosition = PerformOperation(operations[i], roboPosition);
				resultSet.Add(roboPosition);
			}
		}
		return resultSet.Count;
	}

	private static (int X, int Y) PerformOperation(char operation, (int X, int Y) position)
	{
		switch (operation)
		{
			case '^': position.Y--; break;
			case '>': position.X++; break;
			case 'v': position.Y++; break;
			case '<': position.X--; break;
		}

		return position;
	}

	protected override string ParseInput(string inputString)
	{
		return inputString;
	}
}