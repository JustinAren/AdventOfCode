namespace AdventOfCodeBase;

public abstract class DayTest<T> where T : IDay, new()
{
    public abstract void Test1(string inputString, string expected);

    public abstract void Test2(string inputString, string expected);

    public T Day { get; } = new T();
}
