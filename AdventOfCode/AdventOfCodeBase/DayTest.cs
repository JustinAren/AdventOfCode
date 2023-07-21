namespace AdventOfCodeBase;

public abstract class DayTest<T>
    where T : IDay, new()
{
    public abstract void Test1(string inputString, string expected);

    public abstract void Test2(string inputString, string expected);

    protected T Day { get; } = new();
}