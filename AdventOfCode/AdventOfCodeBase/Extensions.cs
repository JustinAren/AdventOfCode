namespace AdventOfCodeBase
{
    public static class Extensions
    {
        public static string[] SplitNewLine(this string inputString) => inputString.Split(Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}