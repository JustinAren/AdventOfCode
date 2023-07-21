namespace AdventOfCode2021;

public class Day04 : Day<Bingo>
{
    protected override Bingo ParseInput(string inputString)
    {
        var boardsInput = inputString.Split($"{Environment.NewLine}{Environment.NewLine}",
            StringSplitOptions.TrimEntries);

        var numbers = boardsInput[0].Split(',').Select(byte.Parse).ToArray();

        var boards = new List<Board>();

        foreach (var boardInput in boardsInput.Skip(1))
        {
            var rows = boardInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var cells = new Cell[5, 5];

            for (var i = 0; i < 5; i++)
            {
                var rowCells = rows[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(number => new Cell(byte.Parse(number))).ToArray();

                for (var j = 0; j < 5; j++) cells[i, j] = rowCells[j];
            }

            boards.Add(new Board(cells));
        }

        return new Bingo(numbers, boards.ToArray());
    }

    public override string Perform1(string inputString)
    {
        var (numbers, boards) = ParseInput(inputString);
        foreach (var number in numbers)
        foreach (var board in boards)
        {
            board.MarkNumber(number);
            if (!board.HasBingo()) continue;

            var unmarkedSum = board.GetUnmarkedSum();
            return (unmarkedSum * number).ToString();
        }

        return 0.ToString();
    }

    public override string Perform2(string inputString)
    {
        var (numbers, boards) = ParseInput(inputString);

        var unmarkedSums = new Dictionary<int, long>();
        var lastWonBoardIndex = 0;

        foreach (var number in numbers)
            for (var i = 0; i < boards.Length; i++)
            {
                if (unmarkedSums.ContainsKey(i)) continue;

                var board = boards[i];
                board.MarkNumber(number);
                if (!board.HasBingo()) continue;

                var unmarkedSum = board.GetUnmarkedSum();
                unmarkedSums[i] = unmarkedSum * number;
                lastWonBoardIndex = i;
            }

        return unmarkedSums[lastWonBoardIndex].ToString();
    }
}

public readonly record struct Bingo(byte[] Numbers, Board[] Boards);

public readonly record struct Board(Cell[,] Cells)
{
    public long GetUnmarkedSum()
    {
        return Cells.Cast<Cell>().Where(cell => !cell.IsMarked)
            .Aggregate(0L, (current, cell) => current + cell.Number);
    }

    public bool HasBingo()
    {
        var cells = Cells;

        if (Enumerable.Range(0, 5).Select(index => cells[index, 0]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[index, 1]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[index, 2]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[index, 3]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[index, 4]).All(cell => cell.IsMarked)) return true;

        if (Enumerable.Range(0, 5).Select(index => cells[0, index]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[1, index]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[2, index]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[3, index]).All(cell => cell.IsMarked)) return true;
        if (Enumerable.Range(0, 5).Select(index => cells[4, index]).All(cell => cell.IsMarked)) return true;

        return false;
    }

    public void MarkNumber(byte number)
    {
        foreach (var cell in Cells) cell.MarkNumber(number);
    }
}

public class Cell
{
    public Cell(byte number) => Number = number;

    public void MarkNumber(byte number)
    {
        if (Number == number) IsMarked = true;
    }

    public bool IsMarked { get; private set; }

    public byte Number { get; }
}