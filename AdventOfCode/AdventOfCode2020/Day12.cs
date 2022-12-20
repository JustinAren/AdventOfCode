namespace AdventOfCode2020;

public class Day12 : Day<IEnumerable<(char Action, int Value)>>
{
    protected override IEnumerable<(char Action, int Value)> ParseInput(string inputString)
    {
        return inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(row => (row[0], int.Parse(row[1..])));
    }

    public override string Perform1(string inputString)
    {
        var instructions = ParseInput(inputString);
        var ship = new Ship();
        foreach (var (action, value) in instructions) ship.PerformInstruction1(action, value);
        return (Math.Abs(ship.XCoordinate) + Math.Abs(ship.YCoordinate)).ToString();
    }

    public override string Perform2(string inputString)
    {
        var instructions = ParseInput(inputString);
        var ship = new Ship();
        foreach (var (action, value) in instructions) ship.PerformInstruction2(action, value);
        return (Math.Abs(ship.XCoordinate) + Math.Abs(ship.YCoordinate)).ToString();
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
    public Ship()
    {
        Direction = Direction.East;
        WayPointXCoordinate = 10;
        WayPointYCoordinate = 1;
    }

    public void PerformInstruction1(char action, int value)
    {
        switch (action)
        {
            case 'N':
                YCoordinate += value;
                break;
            case 'S':
                YCoordinate -= value;
                break;
            case 'E':
                XCoordinate += value;
                break;
            case 'W':
                XCoordinate -= value;
                break;
            case 'L':
                var newDirectionValue = ((int)Direction - value) % 360;
                Direction = (Direction)(newDirectionValue < 0 ? 360 + newDirectionValue : newDirectionValue);
                break;
            case 'R':
                Direction = (Direction)(((int)Direction + value) % 360);
                break;
            case 'F':
                switch (Direction)
                {
                    case Direction.North:
                        YCoordinate += value;
                        break;
                    case Direction.East:
                        XCoordinate += value;
                        break;
                    case Direction.South:
                        YCoordinate -= value;
                        break;
                    case Direction.West:
                        XCoordinate -= value;
                        break;
                }

                break;
        }
    }

    public void PerformInstruction2(char action, int value)
    {
        switch (action)
        {
            case 'N':
                WayPointYCoordinate += value;
                break;
            case 'S':
                WayPointYCoordinate -= value;
                break;
            case 'E':
                WayPointXCoordinate += value;
                break;
            case 'W':
                WayPointXCoordinate -= value;
                break;
            case 'L':
                for (var i = 0; i < value / 90; i++)
                {
                    var newX = WayPointYCoordinate * -1;
                    var newY = WayPointXCoordinate;
                    WayPointYCoordinate = newY;
                    WayPointXCoordinate = newX;
                }

                break;
            case 'R':
                for (var i = 0; i < value / 90; i++)
                {
                    var newX = WayPointYCoordinate;
                    var newY = WayPointXCoordinate * -1;
                    WayPointYCoordinate = newY;
                    WayPointXCoordinate = newX;
                }

                break;
            case 'F':
                XCoordinate += WayPointXCoordinate * value;
                YCoordinate += WayPointYCoordinate * value;
                break;
        }
    }

    public Direction Direction { get; private set; }

    public int WayPointXCoordinate { get; private set; }

    public int WayPointYCoordinate { get; private set; }

    public int XCoordinate { get; private set; }

    public int YCoordinate { get; private set; }
}