namespace AdventOfCode2020;

public class Day17 : Day<HashSet<(int X, int Y, int Z, int W)>>
{
    private static int GetActiveNeighborCount((int X, int Y, int Z, int W) cube,
        IReadOnlySet<(int X, int Y, int Z, int W)> activeCubes, bool useW)
    {
        var activeCount = 0;

        for (var i = -1; i <= 1; i++)
        for (var j = -1; j <= 1; j++)
        for (var k = -1; k <= 1; k++)
        {
            var wLowerBound = useW ? -1 : 0;
            var wUpperBound = useW ? 1 : 0;

            for (var l = wLowerBound; l <= wUpperBound; l++)
            {
                if (i == 0 && j == 0 && k == 0 && l == 0) continue;

                if (activeCubes.Contains((cube.X + i, cube.Y + j, cube.Z + k, cube.W + l)))
                    activeCount++;
            }
        }

        return activeCount;
    }

    private static HashSet<(int X, int Y, int Z, int W)> GetAllNeighbors(
        HashSet<(int X, int Y, int Z, int W)> activeCubes, bool useW)
    {
        var allNeighbors = new HashSet<(int X, int Y, int Z, int W)>();
        foreach (var (x, y, z, w) in activeCubes)
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++)
            for (var k = -1; k <= 1; k++)
            {
                var wLowerBound = useW ? -1 : 0;
                var wUpperBound = useW ? 1 : 0;

                for (var l = wLowerBound; l <= wUpperBound; l++) allNeighbors.Add((x + i, y + j, z + k, w + l));
            }

        return allNeighbors;
    }

    private static HashSet<(int X, int Y, int Z, int W)> PerformCycle(
        HashSet<(int X, int Y, int Z, int W)> activeCubes, bool useW)
    {
        var updatedActiveCubes = new HashSet<(int X, int Y, int Z, int W)>();
        var allNeighbors = GetAllNeighbors(activeCubes, useW);

        foreach (var cube in allNeighbors)
        {
            var active = GetActiveNeighborCount(cube, activeCubes, useW);
            if (activeCubes.Contains(cube))
            {
                if (active is 2 or 3) updatedActiveCubes.Add(cube);
            }
            else
            {
                if (active == 3) updatedActiveCubes.Add(cube);
            }
        }

        return updatedActiveCubes;
    }

    protected override HashSet<(int X, int Y, int Z, int W)> ParseInput(string inputString)
    {
        var input = new HashSet<(int X, int Y, int Z, int W)>();

        var lines = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        for (var x = 0; x < lines.Length; x++)
        for (var y = 0; y < lines[x].Length; y++)
            if (lines[x][y] == '#')
                input.Add((x, y, 0, 0));

        return input;
    }

    public override string Perform1(string inputString)
    {
        var activeCubes = ParseInput(inputString);

        for (var i = 0; i < 6; i++) activeCubes = PerformCycle(activeCubes, false);

        return activeCubes.Count.ToString();
    }

    public override string Perform2(string inputString)
    {
        var activeCubes = ParseInput(inputString);

        for (var i = 0; i < 6; i++) activeCubes = PerformCycle(activeCubes, true);

        return activeCubes.Count.ToString();
    }
}