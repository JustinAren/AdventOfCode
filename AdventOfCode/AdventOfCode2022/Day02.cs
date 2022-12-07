namespace AdventOfCode2022;

public class Day02 : Day<Round[]>
{
	public override long Perform1(string inputString)
	{
		var rounds = this.ParseInput(inputString);
		return rounds.Sum(round => round.Score);
	}

	public override long Perform2(string inputString) => throw new NotImplementedException();
	protected override Round[] ParseInput(string inputString) => inputString
		.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
		.Select(Round.Parse)
		.ToArray();
}

public enum Choice
{
	Rock = 1,
	Paper = 2,
	Scissors = 3,
}

public record Round(Choice OpponentChoice, Choice OwnChoice)
{
	public long Score => this.OpponentChoice switch
	{
		Choice.Rock => this.OwnChoice switch
		{
			Choice.Rock => 4,
			Choice.Paper => 8,
			Choice.Scissors => 3,
			_ => throw new NotSupportedException(),
		},
		Choice.Paper => this.OwnChoice switch
		{
			Choice.Rock => 1,
			Choice.Paper => 5,
			Choice.Scissors => 9,
			_ => throw new NotSupportedException(),
		},
		Choice.Scissors => this.OwnChoice switch
		{
			Choice.Rock => 7,
			Choice.Paper => 2,
			Choice.Scissors => 6,
			_ => throw new NotSupportedException(),
		},
		_ => throw new NotSupportedException(),
	};

	public static Round Parse(string inputString)
	{
		var choices = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		var opponentChoice = choices[0] switch
		{
			"A" => Choice.Rock,
			"B" => Choice.Paper,
			"C" => Choice.Scissors,
			_ => throw new NotSupportedException(),
		};

		var ownChoice = choices[1] switch
		{
			"X" => Choice.Rock,
			"Y" => Choice.Paper,
			"Z" => Choice.Scissors,
			_ => throw new NotSupportedException(),
		};

		return new Round(opponentChoice, ownChoice);
	}
}