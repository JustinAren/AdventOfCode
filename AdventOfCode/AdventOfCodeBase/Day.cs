namespace AdventOfCodeBase;

public abstract class Day<T> : IDay
{
    #region Implementation of IDay

    public (bool Performed, string Result) Perform(int problemNumber, int year)
    {
        var inputString = File.ReadAllText($@"..\..\..\..\InputFiles\{year}\{GetType().Name}.txt");

        return problemNumber switch
        {
            1 => (true, Perform1(inputString)),
            2 => (true, Perform2(inputString)),
            _ => (false, "0"),
        };
    }

    public abstract string Perform1(string inputString);

    public abstract string Perform2(string inputString);

    #endregion

    protected abstract T ParseInput(string inputString);
}

public interface IDay
{
    (bool Performed, string Result) Perform(int problemNumber, int year);

    string Perform1(string inputString);

    string Perform2(string inputString);
}