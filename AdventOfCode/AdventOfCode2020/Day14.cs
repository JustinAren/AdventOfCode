namespace AdventOfCode2020;

public class Day14 : Day<List<BitMaskGroup>>
{
    private static long ApplyBitMask1(string bitMask, long value)
    {
        var binaryValueCharArray = Convert.ToString(value, 2).PadLeft(bitMask.Length, '0').ToArray();

        for (var i = 0; i < bitMask.Length; i++)
        {
            if (bitMask[i] == 'X') continue;
            binaryValueCharArray[i] = bitMask[i];
        }

        return Convert.ToInt64(new string(binaryValueCharArray), 2);
    }

    private static long[] ApplyBitMask2(string bitMask, long position)
    {
        var binaryPositionCharArray = Convert.ToString(position, 2).PadLeft(bitMask.Length, '0').ToArray();

        for (var i = 0; i < bitMask.Length; i++)
        {
            if (bitMask[i] == '0') continue;
            binaryPositionCharArray[i] = bitMask[i];
        }

        var xCount = binaryPositionCharArray.Count(v => v == 'X');
        var newPositionCount = (int)Math.Pow(2, xCount);

        var resultArray = new long[newPositionCount];

        for (var i = 0; i < newPositionCount; i++)
        {
            var iBinary = Convert.ToString(i, 2).PadLeft(xCount, '0');
            var copy = new char[binaryPositionCharArray.Length];
            binaryPositionCharArray.CopyTo((Span<char>)copy);
            var iPosition = 0;
            for (var j = 0; j < copy.Length; j++)
            {
                if (copy[j] != 'X') continue;
                copy[j] = iBinary[iPosition];
                iPosition++;
            }

            resultArray[i] = Convert.ToInt64(new string(copy), 2);
        }

        return resultArray;
    }

    private static void ProcessBitMaskGroup1(BitMaskGroup bitMaskGroup, long[] resultArray)
    {
        foreach (var (position, value) in bitMaskGroup.Operations)
        {
            var newValue = ApplyBitMask1(bitMaskGroup.BitMask, value);
            resultArray[position] = newValue;
        }
    }

    private static void ProcessBitMaskGroup2(BitMaskGroup bitMaskGroup, Dictionary<long, long> resultDictionary)
    {
        foreach (var (position, value) in bitMaskGroup.Operations)
        {
            var newPositions = ApplyBitMask2(bitMaskGroup.BitMask, position);
            foreach (var newPosition in newPositions)
            {
                if (resultDictionary.ContainsKey(newPosition)) resultDictionary[newPosition] = value;
                else resultDictionary.Add(newPosition, value);
            }
        }
    }

    private static (long Position, long Value) ReadOperation(string operation)
    {
        operation = operation.Substring(4);
        var splits = operation.Split("] = ", StringSplitOptions.RemoveEmptyEntries);
        return (long.Parse(splits[0]), long.Parse(splits[1]));
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

    public override long Perform1(string inputString)
    {
        var bitMaskGroups = ParseInput(inputString);
        var arraySize = bitMaskGroups.Max(bmg => bmg.Operations.Max(o => o.Position)) + 1;
        var resultArray = new long[arraySize];

        foreach (var bitMaskGroup in bitMaskGroups) ProcessBitMaskGroup1(bitMaskGroup, resultArray);

        return resultArray.Aggregate((a, b) => a + b);
    }

    public override long Perform2(string inputString)
    {
        var bitMaskGroups = ParseInput(inputString);
        var resultDictionary = new Dictionary<long, long>();

        foreach (var bitMaskGroup in bitMaskGroups) ProcessBitMaskGroup2(bitMaskGroup, resultDictionary);

        return resultDictionary.Values.Aggregate((a, b) => a + b);
    }
}

public class BitMaskGroup
{
    public BitMaskGroup(string bitMask, IEnumerable<(long Position, long Value)> operations)
    {
        BitMask = bitMask;
        Operations = operations.ToList();
    }

    public string BitMask { get; }

    public IReadOnlyCollection<(long Position, long Value)> Operations { get; }
}