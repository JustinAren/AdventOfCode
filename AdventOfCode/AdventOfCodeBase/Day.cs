using System.IO;

namespace AdventOfCodeBase
{
	public abstract class Day<T> : IDay
	{
		public (bool Performed, long Result) Perform(int problemNumber, int year)
		{
			var inputString = File.ReadAllText($@"..\..\..\..\InputFiles\{year}\{this.GetType().Name}.txt");

			return problemNumber switch
			{
				1 => (true, this.Perform1(inputString)),
				2 => (true, this.Perform2(inputString)),
				_ => (false, 0),
			};
		}

		public abstract long Perform1(string inputString);
		public abstract long Perform2(string inputString);
		protected abstract T ParseInput(string inputString);
	}

	public interface IDay
	{
		(bool Performed, long Result) Perform(int problemNumber, int year);
		long Perform1(string inputString);
		long Perform2(string inputString);
	}
}