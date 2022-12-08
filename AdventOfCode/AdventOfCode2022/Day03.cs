namespace AdventOfCode2022;

public class Day03 : Day<Rucksack[]>
{
	public override long Perform1(string inputString)
	{
		var rucksacks = this.ParseInput(inputString);
		return rucksacks.Sum(rucksack => rucksack.GetPriorityOfIntersectingCharacter());
	}
	public override long Perform2(string inputString) => throw new NotImplementedException();
	protected override Rucksack[] ParseInput(string inputString) => inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Rucksack.Parse).ToArray();
}

public record Rucksack(char[] Compartment1, char[] Compartment2)
{
	public static Rucksack Parse(string inputString) =>
		new Rucksack(inputString.Substring(0, inputString.Length / 2).ToCharArray(), inputString.Substring(inputString.Length / 2).ToCharArray());

	public long GetPriorityOfIntersectingCharacter()
	{
		var intersectingCharacter = this.Compartment1.Intersect(this.Compartment2).Single();
		var score = intersectingCharacter >= 'a'
			? intersectingCharacter - 'a' + 1
			: intersectingCharacter - 'A' + 27;
		return score;
	}
}