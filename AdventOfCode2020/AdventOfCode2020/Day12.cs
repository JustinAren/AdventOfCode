using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
	public class Day12 : Day<IEnumerable<(char Action, int Value)>>
	{
		public override ulong Perform1(string inputString)
		{
			var instructions = this.ParseInput(inputString);
			var ship = new Ship();
			foreach (var (action, value) in instructions) ship.PerformInstruction1(action, value);
			return (ulong) (Math.Abs(ship.XCoordinate) + Math.Abs(ship.YCoordinate));
		}

		public override ulong Perform2(string inputString)
		{
			var instructions = this.ParseInput(inputString);
			var ship = new Ship();
			foreach (var (action, value) in instructions) ship.PerformInstruction2(action, value);
			return (ulong) (Math.Abs(ship.XCoordinate) + Math.Abs(ship.YCoordinate));
		}

		protected override IEnumerable<(char Action, int Value)> ParseInput(string inputString)
		{
			return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(row => (row[0], Int32.Parse(row[1..])));
		}
	}

	public enum Direction
	{
		North = 0,
		East = 90,
		South = 180,
		West = 270,
	}

	public class Ship
	{
		public Direction Direction { get; private set; }
		public int XCoordinate { get; private set; }
		public int YCoordinate { get; private set; }
		public int WayPointXCoordinate { get; private set; }
		public int WayPointYCoordinate { get; private set; }

		public Ship()
		{
			this.Direction = Direction.East;
			this.WayPointXCoordinate = 10;
			this.WayPointYCoordinate = 1;
		}

		public void PerformInstruction1(char action, int value)
		{
			switch (action)
			{
				case 'N': this.YCoordinate += value; break;
				case 'S': this.YCoordinate -= value; break;
				case 'E': this.XCoordinate += value; break;
				case 'W': this.XCoordinate -= value; break;
				case 'L':
					var newDirectionValue = ((int) this.Direction - value) % 360;
					this.Direction = (Direction) (newDirectionValue < 0 ? 360 + newDirectionValue : newDirectionValue); 
					break;
				case 'R': this.Direction = (Direction) (((int) this.Direction + value) % 360); break;
				case 'F':
					switch (this.Direction)
					{
						case Direction.North: this.YCoordinate += value; break;
						case Direction.East: this.XCoordinate += value; break;
						case Direction.South: this.YCoordinate -= value; break;
						case Direction.West: this.XCoordinate -= value; break;
					}
					break;
			}
		}

		public void PerformInstruction2(char action, int value)
		{
			switch (action)
			{
				case 'N': this.WayPointYCoordinate += value; break;
				case 'S': this.WayPointYCoordinate -= value; break;
				case 'E': this.WayPointXCoordinate += value; break;
				case 'W': this.WayPointXCoordinate -= value; break;
				case 'L':
					for (var i = 0; i < value / 90; i++)
					{
						var newX = this.WayPointYCoordinate * -1;
						var newY = this.WayPointXCoordinate;
						this.WayPointYCoordinate = newY;
						this.WayPointXCoordinate = newX;
					}
					break;
				case 'R':
					for (var i = 0; i < value / 90; i++)
					{
						var newX = this.WayPointYCoordinate;
						var newY = this.WayPointXCoordinate * -1;
						this.WayPointYCoordinate = newY;
						this.WayPointXCoordinate = newX;
					}
					break;
				case 'F':
					this.XCoordinate += this.WayPointXCoordinate * value;
					this.YCoordinate += this.WayPointYCoordinate * value;
					break;
			}
		}
	}
}
