namespace AdventOfCode2021;

public class Day10 : Day<Chunk[]>
{
	private static readonly IReadOnlyDictionary<char, long> Scores1 = new Dictionary<char, long>()
	{
		{')', 3},
		{']', 57},
		{'}', 1197},
		{'>', 25137},
	};

	private static readonly IReadOnlyDictionary<char, long> Scores2 = new Dictionary<char, long>()
	{
		{')', 1},
		{']', 2},
		{'}', 3},
		{'>', 4},
	};

	public override long Perform1(string inputString)
	{
		var chunks = this.ParseInput(inputString);
		var errors = new List<char>();

		foreach (var chunk in chunks)
		{
			var illegalCharacter = GetFirstIllegalCharacter(chunk);
			if (illegalCharacter != null) errors.Add(illegalCharacter.Value);
		}

		return errors.Sum(c => Scores1[c]);
	}

	public static char? GetFirstIllegalCharacter(Chunk chunk)
	{
		foreach (var innerChunk in chunk.InnerChunks)
		{
			var illegalCharacter = GetFirstIllegalCharacter(innerChunk);
			if (illegalCharacter != null) return illegalCharacter;
		}

		return chunk.IsClosed && !chunk.HasValidClosingCharacter ? chunk.ClosingCharacter : null;
	}

	public override long Perform2(string inputString)
	{
		var chunks = this.ParseInput(inputString);

		var missingEnds = new List<string>();

		foreach (var chunk in chunks)
		{
			var illegalCharacter = GetFirstIllegalCharacter(chunk);
			if (illegalCharacter is not null) continue;
			var missingEnd = chunk.GetMissingEnds();
			if (missingEnd != null) missingEnds.Add(missingEnd);
		}

		var scores = new List<long>();

		foreach (var missingEnd in missingEnds)
		{
			var score = 0L;

			foreach (var end in missingEnd)
			{
				score *= 5;
				score += Scores2[end];
			}

			scores.Add(score);
		}

		scores = scores.OrderBy(score => score).ToList();
		return scores[scores.Count / 2];
	}

	protected override Chunk[] ParseInput(string inputString)
	{
		return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(row => ParseChunk(row.ToList())).ToArray();
	}

	private static Chunk ParseChunk(IList<char> input)
	{
		var chunk = new Chunk(input[0]);
		input.RemoveAt(0);
		
		while (input.Count > 0 && !Scores1.ContainsKey(input[0])) chunk.InnerChunks.Add(ParseChunk(input));

		if (input.Count == 0) return chunk;

		chunk.ClosingCharacter = input[0];
		input.RemoveAt(0);

		return chunk;
	}
}

public class Chunk
{
	private static readonly IReadOnlyDictionary<char, char> Pairs = new Dictionary<char, char>()
	{
		{'(', ')'},
		{'[', ']'},
		{'{', '}'},
		{'<', '>'},
	};

	public char OpeningCharacter { get; }
	public char? ClosingCharacter { get; set; }
	public List<Chunk> InnerChunks { get; set; } = new List<Chunk>();
	public bool IsClosed => this.ClosingCharacter.HasValue;
	public bool HasValidClosingCharacter => this.ClosingCharacter == Pairs[this.OpeningCharacter];

	public Chunk(char openingCharacter)
	{
		this.OpeningCharacter = openingCharacter;
	}

	public string? GetMissingEnds()
	{
		if (this.IsClosed) return null;
		var missingEnds = $"{this.InnerChunks.LastOrDefault()?.GetMissingEnds()}{Pairs[this.OpeningCharacter]}";
		return missingEnds;
	}
}
