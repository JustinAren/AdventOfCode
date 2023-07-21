namespace AdventOfCode2021;

public class Day10 : Day<Chunk[]>
{
    private static readonly IReadOnlyDictionary<char, long> Scores1 = new Dictionary<char, long>
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 }
    };

    private static readonly IReadOnlyDictionary<char, long> Scores2 = new Dictionary<char, long>
    {
        { ')', 1 },
        { ']', 2 },
        { '}', 3 },
        { '>', 4 }
    };

    private static char? GetFirstIllegalCharacter(Chunk chunk)
    {
        var firstIllegalCharacter = chunk.InnerChunks
            .Select(GetFirstIllegalCharacter)
            .FirstOrDefault(illegalCharacter => illegalCharacter != null);

        return firstIllegalCharacter ??
            (chunk is { IsClosed: true, HasValidClosingCharacter: false }
                ? chunk.ClosingCharacter
                : null);
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

    protected override Chunk[] ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(row => ParseChunk(row.ToList())).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var chunks = ParseInput(inputString);
        var errors = (from chunk in chunks
                      select GetFirstIllegalCharacter(chunk)
                      into illegalCharacter
                      where illegalCharacter != null
                      select illegalCharacter.Value).ToList();

        return errors.Sum(error => Scores1[error]).ToString();
    }

    public override string Perform2(string inputString)
    {
        var chunks = ParseInput(inputString);

        var missingEnds = (from chunk in chunks
                           let illegalCharacter = GetFirstIllegalCharacter(chunk)
                           where illegalCharacter is null
                           select chunk.GetMissingEnds()
                           into missingEnd
                           where missingEnd != null
                           select missingEnd).ToList();

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
        return scores[scores.Count / 2].ToString();
    }
}

public class Chunk
{
    private static readonly IReadOnlyDictionary<char, char> Pairs = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
    };

    public Chunk(char openingCharacter) => OpeningCharacter = openingCharacter;

    public string? GetMissingEnds()
    {
        if (IsClosed) return null;
        var missingEnds = $"{InnerChunks.LastOrDefault()?.GetMissingEnds()}{Pairs[OpeningCharacter]}";
        return missingEnds;
    }

    private char OpeningCharacter { get; }

    public char? ClosingCharacter { get; set; }

    public bool HasValidClosingCharacter => ClosingCharacter == Pairs[OpeningCharacter];

    public List<Chunk> InnerChunks { get; } = new();

    public bool IsClosed => ClosingCharacter.HasValue;
}