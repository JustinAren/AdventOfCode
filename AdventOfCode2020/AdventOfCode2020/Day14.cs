using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day14 : Day<List<BitMaskGroup>>
	{
		public override ulong Perform1(string inputString)
		{
			var bitMaskGroups = this.ParseInput(inputString);
			var arraySize = bitMaskGroups.Max(bmg => bmg.Operations.Max(o => o.Position)) + 1;
			var resultArray = new ulong[arraySize];

			foreach (var bitMaskGroup in bitMaskGroups) ProcessBitMaskGroup(bitMaskGroup, resultArray);

			return resultArray.Aggregate((a, b) => a + b);
		}

		public override ulong Perform2(string inputString)
		{
			var bitMaskGroups = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override List<BitMaskGroup> ParseInput(string inputString)
		{
			var bitMaskGroups = new List<BitMaskGroup>();

			var maskGroupStrings = inputString.Trim().Split("mask = ", StringSplitOptions.RemoveEmptyEntries);

			foreach (var maskGroupString in maskGroupStrings)
			{
				var rows = maskGroupString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var operations = rows.Skip(1).Select(ReadOperation);
				bitMaskGroups.Add(new BitMaskGroup(rows[0], operations));
			}

			return bitMaskGroups;
		}

		private static (ulong Position, ulong Value) ReadOperation(string operation)
		{
			operation = operation.Substring(4);
			var splits = operation.Split("] = ", StringSplitOptions.RemoveEmptyEntries);
			return (UInt64.Parse(splits[0]), UInt64.Parse(splits[1]));
		}

		private static ulong ApplyBitMask(string bitMask, ulong value)
		{
			var binaryValueCharArray = Convert.ToString((long) value, 2).PadLeft(bitMask.Length, '0').ToArray();
			var bitMaskPadded = bitMask.PadLeft(binaryValueCharArray.Length, 'X');

			for (var i = 0; i < bitMaskPadded.Length; i++)
			{
				if (bitMaskPadded[i] == 'X') continue;
				binaryValueCharArray[i] = bitMaskPadded[i];
			}

			return Convert.ToUInt64(new string(binaryValueCharArray), 2);
		}

		private static void ProcessBitMaskGroup(BitMaskGroup bitMaskGroup, ulong[] resultArray)
		{
			foreach (var (position, value) in bitMaskGroup.Operations)
			{
				var newValue = ApplyBitMask(bitMaskGroup.BitMask, value);
				resultArray[position] = newValue;
			}
		}
	}

	public class BitMaskGroup
	{
		public string BitMask { get; }
		public IReadOnlyCollection<(ulong Position, ulong Value)> Operations { get; }

		public BitMaskGroup(string bitMask, IEnumerable<(ulong Position, ulong Value)> operations)
		{
			this.BitMask = bitMask;
			this.Operations = operations.ToList();
		}
	}
}
