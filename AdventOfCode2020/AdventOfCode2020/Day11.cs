using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public class Day11 : Day<SeatStatus[,]>
	{
		public override ulong Perform1(string inputString)
		{
			var map = this.ParseInput(inputString);
			var newMap = PerformProblem1Round(map);

			while (!ContentIsEqual(map, newMap))
			{
				map = newMap;
				newMap = PerformProblem1Round(map);
			}

			return GetOccupiedCount(newMap);
		}

		public override ulong Perform2(string inputString)
		{
			var map = this.ParseInput(inputString);
			var newMap = PerformProblem2Round(map);

			while (!ContentIsEqual(map, newMap))
			{
				map = newMap;
				newMap = PerformProblem2Round(map);
			}

			return GetOccupiedCount(newMap);
		}

		private static ulong GetOccupiedCount(SeatStatus[,] map)
		{
			ulong occupiedCount = 0;

			for (var i = 0; i < map.GetLength(0); i++)
			{
				for (var j = 0; j < map.GetLength(1); j++)
				{
					if (map[i, j] == SeatStatus.Occupied) occupiedCount++;
				}
			}

			return occupiedCount;
		}

		private static bool ContentIsEqual(SeatStatus[,] map1, SeatStatus[,] map2)
		{
			if (map1.Length != map2.Length) return false;
			if (map1.GetLength(0) != map2.GetLength(0)) return false;
			for (var i = 0; i < map1.GetLength(0); i++)
			{
				for (var j = 0; j < map1.GetLength(1); j++)
				{
					if (map1[i, j] != map2[i, j]) return false;
				}
			}
			return true;
		}

		private static SeatStatus[,] PerformProblem1Round(SeatStatus[,] map)
		{
			var newMap = new SeatStatus[map.GetLength(0), map.GetLength(1)];

			for (var i = 0; i < map.GetLength(0); i++)
			{
				for (var j = 0; j < map.GetLength(1); j++)
				{
					var adjacentSeats = GetAdjacentSeats(map, i, j).ToArray();
					newMap[i, j] = map[i, j] switch
					{
						SeatStatus.Floor => SeatStatus.Floor,
						SeatStatus.Empty when adjacentSeats.All(seat => seat != SeatStatus.Occupied) => SeatStatus.Occupied,
						SeatStatus.Occupied when adjacentSeats.Count(seat => seat == SeatStatus.Occupied) >= 4 => SeatStatus.Empty,
						_ => map[i, j],
					};
				}
			}

			return newMap;
		}

		private static IEnumerable<SeatStatus> GetAdjacentSeats(SeatStatus[,] map, int x, int y)
		{
			var result = new List<SeatStatus>();
			for (var i = x - 1; i <= x + 1; i++)
			{
				if (i < 0) continue;
				if (i >= map.GetLength(0)) continue;

				for (var j = y - 1; j <= y + 1; j++)
				{
					if (j < 0) continue;
					if (j >= map.GetLength(1)) continue;
					if (i == x && j == y) continue;

					result.Add(map[i, j]);
				}
			}
			return result;
		}

		private static SeatStatus[,] PerformProblem2Round(SeatStatus[,] map)
		{
			var newMap = new SeatStatus[map.GetLength(0), map.GetLength(1)];

			for (var i = 0; i < map.GetLength(0); i++)
			{
				for (var j = 0; j < map.GetLength(1); j++)
				{
					var visibleSeats = GetVisibleSeats(map, i, j).ToArray();
					newMap[i, j] = map[i, j] switch
					{
						SeatStatus.Floor => SeatStatus.Floor,
						SeatStatus.Empty when visibleSeats.All(seat => seat != SeatStatus.Occupied) => SeatStatus.Occupied,
						SeatStatus.Occupied when visibleSeats.Count(seat => seat == SeatStatus.Occupied) >= 5 => SeatStatus.Empty,
						_ => map[i, j],
					};
				}
			}

			return newMap;
		}

		private static IEnumerable<SeatStatus> GetVisibleSeats(SeatStatus[,] map, int x, int y)
		{
			var result = new List<SeatStatus>();

			for (var i = x + 1; i < map.GetLength(0); i++)
			{
				if (map[i, y] == SeatStatus.Floor) continue;

				result.Add(map[i, y]);
				break;
			}

			for (var i = x - 1; i >= 0; i--)
			{
				if (map[i, y] == SeatStatus.Floor) continue;

				result.Add(map[i, y]);
				break;
			}

			for (var j = y + 1; j < map.GetLength(1); j++)
			{
				if (map[x, j] == SeatStatus.Floor) continue;

				result.Add(map[x, j]);
				break;
			}

			for (var j = y - 1; j >= 0; j--)
			{
				if (map[x, j] == SeatStatus.Floor) continue;

				result.Add(map[x, j]);
				break;
			}

			for (var i = 1; i < map.GetLength(0); i++)
			{
				if (x + i >= map.GetLength(0)) break;
				if (y + i >= map.GetLength(1)) break;

				if (map[x + i, y + i] == SeatStatus.Floor) continue;

				result.Add(map[x + i, y + i]);
				break;
			}

			for (var i = 1; i < map.GetLength(0); i++)
			{
				if (x - i < 0) break;
				if (y + i >= map.GetLength(1)) break;

				if (map[x - i, y + i] == SeatStatus.Floor) continue;

				result.Add(map[x - i, y + i]);
				break;
			}

			for (var i = 1; i < map.GetLength(0); i++)
			{
				if (x + i >= map.GetLength(0)) break;
				if (y - i < 0) break;

				if (map[x + i, y - i] == SeatStatus.Floor) continue;

				result.Add(map[x + i, y - i]);
				break;
			}

			for (var i = 1; i < map.GetLength(0); i++)
			{
				if (x - i < 0) break;
				if (y - i < 0) break;

				if (map[x - i, y - i] == SeatStatus.Floor) continue;

				result.Add(map[x - i, y - i]);
				break;
			}

			return result;
		}

		protected override SeatStatus[,] ParseInput(string inputString)
		{
			var rows = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			var map = new SeatStatus[rows.Length, rows[0].Length];
			for (var i = 0; i < rows.Length; i++)
			{
				var seats = rows[i].Select(ParseSeatStatus).ToArray();
				for (var j = 0; j < seats.Length; j++) map[i, j] = seats[j];
			}
			return map;
		}

		private static SeatStatus ParseSeatStatus(char character)
		{
			return character switch
			{
				'.' => SeatStatus.Floor,
				'L' => SeatStatus.Empty,
				'#' => SeatStatus.Occupied,
				_ => throw new NotSupportedException($"Character \'{character}\' is not a known {nameof(SeatStatus)}.")
			};
		}
	}

	public enum SeatStatus
	{
		Floor,
		Empty,
		Occupied,
	}
}
