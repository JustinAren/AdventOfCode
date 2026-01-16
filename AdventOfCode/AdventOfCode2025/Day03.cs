using System.Text;

namespace AdventOfCode2025;

public class Day03 : Day<List<string>>
{
    private static long CalculateJoltage(string bank, int batteryCount)
    {
        var joltageSb = new StringBuilder(batteryCount);

        while (batteryCount > 0)
        {
            var length = batteryCount == 1 ? bank.Length : (bank.Length - batteryCount) + 1;
            var maxChar = bank[..length].Max();
            var maxCharIndex = bank.IndexOf(maxChar);
            joltageSb.Append(maxChar);
            bank = bank.Remove(0, maxCharIndex + 1);
            batteryCount--;
        }

        return long.Parse(joltageSb.ToString());
    }

    protected override List<string> ParseInput(string inputString) => inputString.SplitNewLine().ToList();

    public override string Perform1(string inputString)
    {
        var banks = ParseInput(inputString);
        var result = banks.Sum(bank => CalculateJoltage(bank, 2));
        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var banks = ParseInput(inputString);
        var result = banks.Sum(bank => CalculateJoltage(bank, 12));
        return result.ToString();
    }
}