﻿namespace AdventOfCode2022;

public class Day01 : Day<long[][]>
{
    protected override long[][] ParseInput(string inputString) => inputString
        .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
        .Select(group => group.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToArray())
        .ToArray();

    public override long Perform1(string inputString)
    {
        var groups = ParseInput(inputString);
        return groups.Select(group => group.Sum()).Max();
    }

    public override long Perform2(string inputString)
    {
        throw new NotImplementedException();
    }
}