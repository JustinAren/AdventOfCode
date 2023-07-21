namespace AdventOfCode2015;

public class Day01 : Day<string>
{
    protected override string ParseInput(string inputString) => inputString;

    public override string Perform1(string inputString)
    {
        var result = 0;

        foreach (var character in inputString)
            switch (character)
            {
                case '(':
                    result++;
                    break;

                case ')':
                    result--;
                    break;
            }

        return result.ToString();
    }

    public override string Perform2(string inputString)
    {
        var result = 0;

        for (var i = 0; i < inputString.Length; i++)
        {
            switch (inputString[i])
            {
                case '(':
                    result++;
                    break;

                case ')':
                    result--;
                    break;
            }

            if (result == -1) return (i + 1).ToString();
        }

        return 0.ToString();
    }
}