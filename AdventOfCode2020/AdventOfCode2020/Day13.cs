﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day13 : Day<(ulong TimeStamp, int[] BusNumbers)>
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
			var (_, busNumbers) = this.ParseInput(inputString);

			var remainders = new List<(ulong Id, ulong Remainder)>();
			for (byte i = 0; i < busNumbers.Length; i++) if (busNumbers[i] > 0) remainders.Add(((ulong)busNumbers[i], i));
			
			var timestamp = remainders[0].Id;
			var increment = remainders[0].Id;

			foreach (var (id, remainder) in remainders.Skip(1))
			{
				while((timestamp + remainder) % id != 0) timestamp += increment;
				increment *= id;
			}

			return timestamp;
		}

		protected override (ulong TimeStamp, int[] BusNumbers) ParseInput(string inputString)
		{
			var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var timeStamp = UInt64.Parse(rows[0]);
			var busNumbers = rows[1].Split(',').Select(s => Int32.TryParse(s, out var number) ? number : -1).ToArray();
			return (timeStamp, busNumbers);
		}
	}
}
