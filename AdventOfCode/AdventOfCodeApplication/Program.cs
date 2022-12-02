using System.Diagnostics;

using AdventOfCode2015;

namespace AdventOfCodeApplication;

public class Program
{
    public static void Main()
    {
        var stopwatch = new Stopwatch();
        while (true)
        {
            Console.WriteLine("Which year?");
            var yearString = Console.ReadLine();

            if (yearString?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? true) break;
            if (!int.TryParse(yearString, out var year))
            {
                Console.WriteLine($"Unknown year: {yearString}");
                continue;
            }

            Console.WriteLine("Which day?");
            var dayString = Console.ReadLine();

            if (dayString?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? true) break;
            if (!int.TryParse(dayString, out var dayNumber))
            {
                Console.WriteLine($"Unknown day: {dayString}");
                continue;
            }

            Console.WriteLine("Which problem?");
            var problemString = Console.ReadLine();

            if (problemString?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? true) break;
            if (!int.TryParse(problemString, out var problemNumber))
            {
                Console.WriteLine($"Unknown problem: {problemString}");
                continue;
            }

            var dayType = year switch
            {
                2015 => typeof(Day01).Assembly.GetType($"AdventOfCode{year:D4}.Day{dayNumber:D2}"),
                2020 => typeof(AdventOfCode2020.Day01).Assembly.GetType(
                    $"AdventOfCode{year:D4}.Day{dayNumber:D2}"),
                2021 => typeof(AdventOfCode2021.Day01).Assembly.GetType(
                    $"AdventOfCode{year:D4}.Day{dayNumber:D2}"),
                2022 => typeof(AdventOfCode2022.Day01).Assembly.GetType(
                    $"AdventOfCode{year:D4}.Day{dayNumber:D2}"),
                _ => null,
            };

            if (dayType is null)
            {
                Console.WriteLine($"Implementation of AdventOfCode{year:D4}.Day{dayNumber:D2} does not exist");
                continue;
            }

            var day = Activator.CreateInstance(dayType) as IDay;
            if (day is null)
            {
                Console.WriteLine(
                    $"Implementation of AdventOfCode{year:D4}.Day{dayNumber:D2} cannot be created");
                continue;
            }

            stopwatch.Start();
            var (performed, result) = day.Perform(problemNumber, year);
            stopwatch.Stop();
            if (!performed)
            {
                Console.WriteLine(
                    $"Implementation of AdventOfCode{year:D4}.Day{dayNumber:D2} Problem {problemNumber} cannot be performed");
                continue;
            }

            Console.WriteLine(
                $"Solution of Year {year:D4}, Day {dayNumber:D2}, Problem {problemNumber} is: {result}. Performed in {stopwatch.Elapsed:c}.");

            stopwatch.Reset();
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}