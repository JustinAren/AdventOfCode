using System;
using System.Diagnostics;

namespace AdventOfCode2020
{
	public class Program
	{
		public static void Main()
		{
			var stopwatch = new Stopwatch();
			while (true)
			{
				Console.WriteLine("Which day?");
				var dayString = Console.ReadLine();

				if (dayString?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? true) break;
				if (!Int32.TryParse(dayString, out var dayNumber)) continue;
				
				Console.WriteLine("Which problem?");
				var problemString = Console.ReadLine();
				
				if (problemString?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? true) break;
				if (!Int32.TryParse(problemString, out var problemNumber)) continue;

				var dayType = typeof(Program).Assembly.GetType($"AdventOfCode2020.Day{dayNumber:D2}");
				if (dayType is null) continue;

				var day = Activator.CreateInstance(dayType) as Day;
				if (day is null) continue;

				stopwatch.Start();
				var (performed, result) = day.Perform(problemNumber);
				stopwatch.Stop();
				if (!performed) continue;

				Console.WriteLine($"Solution of Day{dayNumber:D2} Problem {problemNumber} is: {result}. Performed in {stopwatch.Elapsed:c}.");

				stopwatch.Reset();
			}

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
