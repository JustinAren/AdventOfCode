using System.IO;

namespace AdventOfCodeBase
{
	public abstract class Day<T> : IDay
	{
		public (bool Performed, ulong Result) Perform(int problemNumber, int year)
		{
			var inputString = File.ReadAllText($@"..\..\..\..\InputFiles\{year}\{this.GetType().Name}.txt");

			return problemNumber switch
			{
				1 => (true, this.Perform1(inputString)),
				2 => (true, this.Perform2(inputString)),
				_ => (false, 0),
			};
		}

		public abstract ulong Perform1(string inputString);
		public abstract ulong Perform2(string inputString);
		protected abstract T ParseInput(string inputString);
	}

	public interface IDay
	{
		(bool Performed, ulong Result) Perform(int problemNumber, int year);
		ulong Perform1(string inputString);
		ulong Perform2(string inputString);
	}
}