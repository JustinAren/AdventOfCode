using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
	public abstract class Day
	{
		public (bool Performed, int Result) Perform(int problemNumber)
		{
			var inputFile = File.ReadAllText($@"InputFiles\{this.GetType().Name}.txt");
			var intArray = inputFile.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();

			switch (problemNumber)
			{
				case 1: return (true, this.Perform1(intArray));
				case 2: return (true, this.Perform2(intArray));
			}

			return (false, 0);
		}

		public abstract int Perform1(int[] intArray);
		public abstract int Perform2(int[] intArray);
	}
}
