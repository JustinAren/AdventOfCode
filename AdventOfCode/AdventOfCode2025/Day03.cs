namespace AdventOfCode2025;

public class Day03 : Day<List<string>>
{
    protected override List<string> ParseInput(string inputString) => inputString.SplitNewLine().ToList();

    public override string Perform1(string inputString)
    {
        var banks = ParseInput(inputString);
        var result = 0L;

        foreach (var bank in banks)
        {
            var joltage = 0;

            for (var i = 0; i < bank.Length - 1; i++)
            {
                for (var j = i + 1; j < bank.Length; j++)
                {
                    var value = int.Parse($"{bank[i]}{bank[j]}");
                    if (value > joltage) joltage = value;
                }
            }

            result += joltage;
        }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var ranges = ParseInput(inputString);
        var result = 0L;
        return result.ToString();
    }
}