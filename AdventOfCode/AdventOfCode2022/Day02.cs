namespace AdventOfCode2022;

public class Day02 : Day<Round[]>
{
    protected override Round[] ParseInput(string inputString) =>
        inputString.SplitNewLine().Select(Round.Parse).ToArray();

    public override string Perform1(string inputString)
    {
        var rounds = ParseInput(inputString);
        return rounds.Sum(round => round.Score).ToString();
    }

    public override string Perform2(string inputString)
    {
        var rounds = ParseInput(inputString);
        return rounds.Sum(round => round.Score2).ToString();
    }
}

public enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum Outcome
{
    Win,
    Lose,
    Draw
}

public record Round(Choice OpponentChoice, Choice OwnChoice, Outcome Outcome)
{
    private static Choice DetermineOwnChoice(Choice opponentChoice, Outcome outcome) => opponentChoice switch
    {
        Choice.Rock => outcome switch
        {
            Outcome.Win => Choice.Paper,
            Outcome.Draw => Choice.Rock,
            Outcome.Lose => Choice.Scissors,
            _ => throw new NotSupportedException()
        },
        Choice.Paper => outcome switch
        {
            Outcome.Win => Choice.Scissors,
            Outcome.Draw => Choice.Paper,
            Outcome.Lose => Choice.Rock,
            _ => throw new NotSupportedException()
        },
        Choice.Scissors => outcome switch
        {
            Outcome.Win => Choice.Rock,
            Outcome.Draw => Choice.Scissors,
            Outcome.Lose => Choice.Paper,
            _ => throw new NotSupportedException()
        },
        _ => throw new NotSupportedException()
    };

    private static int DetermineScore(Choice opponentChoice, Choice ownChoice) => opponentChoice switch
    {
        Choice.Rock => ownChoice switch
        {
            Choice.Rock => 4,
            Choice.Paper => 8,
            Choice.Scissors => 3,
            _ => throw new NotSupportedException()
        },
        Choice.Paper => ownChoice switch
        {
            Choice.Rock => 1,
            Choice.Paper => 5,
            Choice.Scissors => 9,
            _ => throw new NotSupportedException()
        },
        Choice.Scissors => ownChoice switch
        {
            Choice.Rock => 7,
            Choice.Paper => 2,
            Choice.Scissors => 6,
            _ => throw new NotSupportedException()
        },
        _ => throw new NotSupportedException()
    };

    public static Round Parse(string inputString)
    {
        var choices = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var opponentChoice = choices[0] switch
        {
            "A" => Choice.Rock,
            "B" => Choice.Paper,
            "C" => Choice.Scissors,
            _ => throw new NotSupportedException()
        };

        Choice ownChoice;
        Outcome outcome;

        switch (choices[1])
        {
            case "X":
                ownChoice = Choice.Rock;
                outcome = Outcome.Lose;
                break;

            case "Y":
                ownChoice = Choice.Paper;
                outcome = Outcome.Draw;
                break;

            case "Z":
                ownChoice = Choice.Scissors;
                outcome = Outcome.Win;
                break;

            default: throw new NotSupportedException();
        }

        return new Round(opponentChoice, ownChoice, outcome);
    }

    public long Score => DetermineScore(OpponentChoice, OwnChoice);

    public long Score2 => DetermineScore(OpponentChoice, DetermineOwnChoice(OpponentChoice, Outcome));
}