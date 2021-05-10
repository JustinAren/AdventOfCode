using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
	public class Day17 : Day<HashSet<(int X, int Y, int Z)>>
	{
		public override ulong Perform1(string inputString)
		{
			var activeCubes = this.ParseInput(inputString);

			for (var i = 0; i < 6; i++) activeCubes = PerformCycle(activeCubes);

			return (ulong) activeCubes.Count;
		}

		public override ulong Perform2(string inputString)
		{
			var input = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override HashSet<(int X, int Y, int Z)> ParseInput(string inputString)
		{
			var input = new HashSet<(int X, int Y, int Z)>();

			var lines = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			for (var x = 0; x < lines.Length; x++)
			{
				for (var y = 0; y < lines[x].Length; y++)
				{
					if (lines[x][y] == '#') input.Add((x, y, 0));
				}
			}

			return input;
		}

		private static HashSet<(int X, int Y, int Z)> PerformCycle(HashSet<(int X, int Y, int Z)> activeCubes)
		{
			var updatedActiveCubes = new HashSet<(int X, int Y, int Z)>();
			var allNeighbors = GetAllNeighbors(activeCubes);

			foreach (var cube in allNeighbors)
			{
				var (active, inactive) = GetActiveNeighborCount(cube, activeCubes);
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

		private static HashSet<(int X, int Y, int Z)> GetAllNeighbors(HashSet<(int X, int Y, int Z)> activeCubes)
		{
			var allNeighbors = new HashSet<(int x, int y, int z)>();
			foreach (var (x, y, z) in activeCubes)
			{
				for (var i = -1; i <= 1; i++)
				{
					for (var j = -1; j <= 1; j++)
					{
						for (var k = -1; k <= 1; k++)
						{
							allNeighbors.Add((x + i, y + j, z + k));
						}
					}
				}
			}
			return allNeighbors;
		}

		private static (int Active, int Inactive) GetActiveNeighborCount((int X, int Y, int Z) cube, HashSet<(int X, int Y, int Z)> activeCubes)
		{
			var activeCount = 0;
			var inactiveCount = 0;

			for (var i = -1; i <= 1; i++)
			{
				for (var j = -1; j <= 1; j++)
				{
					for (var k = -1; k <= 1; k++)
					{
						if (i == 0 && j == 0 && k == 0) continue;
						
						if (activeCubes.Contains((cube.X + i, cube.Y + j, cube.Z + k))) activeCount++;
						else inactiveCount++;
					}
				}
			}

			return (activeCount, inactiveCount);
		}
	}
}
