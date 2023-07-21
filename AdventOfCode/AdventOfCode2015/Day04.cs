using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015;

public class Day04 : Day<string>
{
    private static string GenerateMd5(string input)
    {
        // Use input string to calculate MD5 hash
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);

        // Convert the byte array to hexadecimal string
        var sb = new StringBuilder();
        foreach (var b in hashBytes) sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    private static long Perform(byte leadingZeroes, string secretKey)
    {
        var counter = 0L;
        var prefix = new string('0', leadingZeroes);

        while (true)
        {
            counter++;
            var md5 = GenerateMd5($"{secretKey}{counter}");
            if (md5.StartsWith(prefix)) return counter;
        }
    }

    protected override string ParseInput(string inputString) => inputString;

    public override string Perform1(string inputString)
    {
        var secretKey = ParseInput(inputString);
        return Perform(5, secretKey).ToString();
    }

    public override string Perform2(string inputString)
    {
        var secretKey = ParseInput(inputString);
        return Perform(6, secretKey).ToString();
    }
}