namespace AdventOfCode2021;

public class Day04 : Day<Bingo>
{
	public override long Perform1(string inputString)
	{
		var (numbers, boards) = this.ParseInput(inputString);
		foreach (var number in numbers)
		{
			foreach (var board in boards)
			{
				board.MarkNumber(number);
				if (!board.HasBingo()) continue;

				var unmarkedSum = board.GetUnmarkedSum();
				return unmarkedSum * number;
			}
		}

		return 0;
	}

	public override long Perform2(string inputString)
	{
		throw new NotImplementedException();
	}

	protected override Bingo ParseInput(string inputString)
	{
		var boardsInput = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.TrimEntries);
		var numbers = boardsInput[0].Split(',').Select(Byte.Parse).ToArray();

		var boards = new List<Board>();

		foreach (var boardInput in boardsInput.Skip(1))
		{
			var rows = boardInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var cells = new Cell[5, 5];

			for (var i = 0; i < 5; i++)
			{
				var rowCells = rows[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(number => new Cell(Byte.Parse(number))).ToArray();
				for (var j = 0; j < 5; j++) cells[i, j] = rowCells[j];
			}

			boards.Add(new Board(cells));
		}

		return new Bingo(numbers, boards.ToArray());
	}
}

public readonly record struct Bingo(byte[] Numbers, Board[] Boards);

public readonly record struct Board(Cell[,] Cells)
{
	public void MarkNumber(byte number)
	{
		foreach (var cell in this.Cells) cell.MarkNumber(number);
	}

	public bool HasBingo()
	{
		var cells = this.Cells;

		if (Enumerable.Range(0, 5).Select(i => cells[i, 0]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[i, 1]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[i, 2]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[i, 3]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[i, 4]).All(c => c.IsMarked)) return true;

		if (Enumerable.Range(0, 5).Select(i => cells[0, i]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[1, i]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[2, i]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[3, i]).All(c => c.IsMarked)) return true;
		if (Enumerable.Range(0, 5).Select(i => cells[4, i]).All(c => c.IsMarked)) return true;

		return false;
	}

	public long GetUnmarkedSum()
	{
		return this.Cells.Cast<Cell>().Where(cell => !cell.IsMarked).Aggregate(0L, (current, cell) => current + cell.Number);
	}
}

public class Cell
{
	public byte Number { get; }
	public bool IsMarked { get; private set; }

	public Cell(byte number)
	{
		this.Number = number;
	}

	public void MarkNumber(byte number)
	{
		if (this.Number == number) this.IsMarked = true;
	}
}
