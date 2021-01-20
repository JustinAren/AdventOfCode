using System;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day13 : Day<(ulong TimeStamp, short[] BusNumbers)>
	{
		public override ulong Perform1(string inputString)
		{
			var (currentTimeStamp, busNumbers) = this.ParseInput(inputString);
			var departureTimeStamp = UInt64.MaxValue;
			ulong usedBusNumber = 0;

			foreach (var s in busNumbers.Where(number => number > 0))
			{
				var busNumber = (ulong) s;
				var nextDepartureTimeStamp = busNumber * (currentTimeStamp / busNumber + 1);
				if (departureTimeStamp <= nextDepartureTimeStamp) continue;

				departureTimeStamp = nextDepartureTimeStamp;
				usedBusNumber = busNumber;
			}

			return (departureTimeStamp - currentTimeStamp) * usedBusNumber;
		}

		public override ulong Perform2(string inputString)
		{
			var (timeStamp, busNumbers) = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override (ulong TimeStamp, short[] BusNumbers) ParseInput(string inputString)
		{
			var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var timeStamp = UInt64.Parse(rows[0]);
			var busNumbers = rows[1].Split(',').Select(s => Int16.TryParse(s, out var number) ? number : (short) -1).ToArray();
			return (timeStamp, busNumbers);
		}
	}
}
