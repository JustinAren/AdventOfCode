namespace AdventOfCode2020;

public class Day07 : Day<IEnumerable<Bag>>
{
	private const string BagColor = "shiny gold";

	public override long Perform1(string inputString)
	{
		var foundColors = new HashSet<string>();
		var bags = this.ParseInput(inputString);

		foreach (var bag in bags)
		{
			if (bag.Color == BagColor) continue;
			if (FindColor(bag)) foundColors.Add(bag.Color);
		}

		return foundColors.Count;

		static bool FindColor(Bag bag)
		{
			foreach (var containedBag in bag.Contains.Keys)
			{
				if (containedBag.Color == BagColor) return true;
				if (FindColor(containedBag)) return true;
			}
			return false;
		}
	}

	public override long Perform2(string inputString)
	{
		var bags = this.ParseInput(inputString).ToDictionary(bag => bag.Color);
		return bags[BagColor].BagCount - 1;
	}

	protected override IEnumerable<Bag> ParseInput(string inputString)
	{
		inputString = inputString.Replace(" bags", "").Replace(" bag", "").Replace(".", "");
		var result = new Dictionary<string, Bag>();

		var descriptions = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		foreach (var description in descriptions)
		{
			var color = description.Split("contain")[0].Trim();
			result.Add(color, new Bag(color));
		}

		foreach (var description in descriptions)
		{
			var split = description.Split("contain");
			var bag = result[split[0].Trim()];
			var contains = split[1].Trim();
			var colorsAndCounts = contains.Split(",", StringSplitOptions.RemoveEmptyEntries);

			foreach (var colorWithCount in colorsAndCounts)
			{
				if (colorWithCount.Contains("no other")) break;
				var colorWithCountSplit = colorWithCount.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				var count = Int32.Parse(colorWithCountSplit[0].Trim());
				var color = $"{colorWithCountSplit[1]} {colorWithCountSplit[2]}";
				bag.Contains.Add(result[color], count);
			}
		}

		return result.Values.ToList();
	}
}

public class Bag
{
	public string Color { get; }
	public Dictionary<Bag, int> Contains { get; } = new Dictionary<Bag, int>();
	public int BagCount => this.Contains.Sum(kvp => kvp.Key.BagCount * kvp.Value) + 1;

	public Bag(string color)
	{
		this.Color = color;
	}
}