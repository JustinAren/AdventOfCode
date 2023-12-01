namespace AdventOfCode2022;

public class Day03 : Day<Rucksack[]>
{
    protected override Rucksack[] ParseInput(string inputString) =>
        inputString.SplitNewLine().Select(Rucksack.Parse).ToArray();

    public override string Perform1(string inputString)
    {
        var rucksacks = ParseInput(inputString);
        return rucksacks.Sum(rucksack => rucksack.GetPriorityOfIntersectingCharacter()).ToString();
    }

    public override string Perform2(string inputString)
    {
        var rucksacks = ParseInput(inputString);

        var score = 0L;

        for (var i = 0; i < rucksacks.Length; i += 3)
        {
            var intersectingChar = rucksacks[i].Content.Intersect(rucksacks[i + 1].Content)
                .Intersect(rucksacks[i + 2].Content).Single();

            score += Rucksack.GetPriorityOfCharacter(intersectingChar);
        }

        return score.ToString();
    }
}

public record Rucksack(string Compartment1, string Compartment2)
{
    public static long GetPriorityOfCharacter(char c) => c >= 'a' ? (c - 'a') + 1 : (c - 'A') + 27;

    public static Rucksack Parse(string inputString) =>
        new(inputString[..(inputString.Length / 2)],
            inputString[(inputString.Length / 2)..]);

    public long GetPriorityOfIntersectingCharacter()
    {
        var intersectingCharacter = Compartment1.Intersect(Compartment2).Single();
        return GetPriorityOfCharacter(intersectingCharacter);
    }

    public string Content => Compartment1 + Compartment2;
}