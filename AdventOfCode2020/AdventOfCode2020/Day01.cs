namespace AdventOfCode2020
{
	public class Day01 : Day
	{
		public override int Perform1(int[] intArray)
		{
			var result = 0;
			foreach (var a in intArray)
			{
				foreach (var b in intArray)
				{
					if (a == b) continue;
					if (a + b != 2020) continue;
					result = a * b;
					break;
				}
				if (result != 0) break;
			}
			return result;
		}

		public override int Perform2(int[] intArray)
		{
			var result = 0;
			foreach (var a in intArray)
			{
				foreach (var b in intArray)
				{
					foreach (var c in intArray)
					{
						if (a == b || b == c || a == c) continue;
						if (a + b + c != 2020) continue;
						result = a * b * c;
						break;
					}
					if (result != 0) break;
				}
				if (result != 0) break;
			}
			return result;
		}
	}
}
