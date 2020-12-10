using System.IO;

namespace AdventOfCode2020
{
	public abstract class Day
	{
		public (bool Performed, string Result) Perform(int problemNumber)
		{
			var inputString = File.ReadAllText($@"InputFiles\{this.GetType().Name}.txt");

			switch (problemNumber)
			{
				case 1: return (true, this.Perform1(inputString));
				case 2: return (true, this.Perform2(inputString));
			}

			return (false, null);
		}

		public abstract string Perform1(string inputString);
		public abstract string Perform2(string inputString);
	}
}
