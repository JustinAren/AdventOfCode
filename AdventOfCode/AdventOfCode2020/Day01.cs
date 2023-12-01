namespace AdventOfCode2020;

public class Day01 : Day<int[]>
{
    protected override int[] ParseInput(string inputString) =>
        inputString.SplitNewLine().Select(int.Parse).ToArray();

    public override string Perform1(string inputString)
    {
        var intArray = ParseInput(inputString);
        var result = 0;
        foreach (var a in intArray)
        {
            foreach (var b in intArray)
            {
                if (a == b) continue;
                if (a + b != 2020) continue;
                result = a * b;
                break;
            }

            if (result != 0) break;
        }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var intArray = ParseInput(inputString);
        var result = 0;
        foreach (var a in intArray)
        {
            foreach (var b in intArray)
            {
                foreach (var c in intArray)
                {
                    if (a == b || b == c || a == c) continue;
                    if (a + b + c != 2020) continue;
                    result = a * b * c;
                    break;
                }

                if (result != 0) break;
            }

            if (result != 0) break;
        }

        return result.ToString();
    }
}