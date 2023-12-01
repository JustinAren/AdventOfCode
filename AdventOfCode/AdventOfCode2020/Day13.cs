namespace AdventOfCode2020;

public class Day13 : Day<(long TimeStamp, int[] BusNumbers)>
{
    protected override (long TimeStamp, int[] BusNumbers) ParseInput(string inputString)
    {
        var rows = inputString.SplitNewLine();
        var timeStamp = long.Parse(rows[0]);
        var busNumbers = rows[1].Split(',').Select(num => int.TryParse(num, out var number) ? number : -1)
            .ToArray();

        return (timeStamp, busNumbers);
    }

    public override string Perform1(string inputString)
    {
        var (currentTimeStamp, busNumbers) = ParseInput(inputString);
        var departureTimeStamp = long.MaxValue;
        long usedBusNumber = 0;

        foreach (var s in busNumbers.Where(number => number > 0))
        {
            var busNumber = (long)s;
            var nextDepartureTimeStamp = busNumber * ((currentTimeStamp / busNumber) + 1);
            if (departureTimeStamp <= nextDepartureTimeStamp) continue;

            departureTimeStamp = nextDepartureTimeStamp;
            usedBusNumber = busNumber;
        }

        return ((departureTimeStamp - currentTimeStamp) * usedBusNumber).ToString();
    }

    public override string Perform2(string inputString)
    {
        var (_, busNumbers) = ParseInput(inputString);

        var remainders = new List<(long Id, long Remainder)>();
        for (byte i = 0; i < busNumbers.Length; i++)
            if (busNumbers[i] > 0)
                remainders.Add((busNumbers[i], i));

        var timestamp = remainders[0].Id;
        var increment = remainders[0].Id;

        foreach (var (id, remainder) in remainders.Skip(1))
        {
            while ((timestamp + remainder) % id != 0) timestamp += increment;
            increment *= id;
        }

        return timestamp.ToString();
    }
}