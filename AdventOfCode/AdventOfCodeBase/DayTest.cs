namespace AdventOfCodeBase;

public abstract class DayTest<T> where T : IDay, new()
{
	public T Day { get; } = new T();

	public abstract void Test1(string inputString, long expected);
	public abstract void Test2(string inputString, long expected);
}
