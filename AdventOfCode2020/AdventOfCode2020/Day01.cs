namespace AdventOfCode2020
{
	public class Day01
	{
		public static int Perform(int[] intArray)
		{
			var result = 0;
			foreach (var a in intArray)
			{
				foreach (var b in intArray)
				{
					if (a == b) continue;

					if (a + b == 2020)
					{
						result = a * b;
						break;
					}
				}

				if (result != 0) break;
			}

			return result;
		}
	}
}
