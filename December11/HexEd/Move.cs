using System.Collections.Generic;

namespace HexEd
{
    public class Direction
    {
        public static Direction NW = new Direction(-1, 1);
        public static Direction N = new Direction(0, 2);
        public static Direction NE = new Direction(1, 1);
        public static Direction SW = new Direction(-1, -1);
        public static Direction S = new Direction(0, -2);
        public static Direction SE = new Direction(1, -1);

        private static readonly Dictionary<string, Direction> _map = new Dictionary<string, Direction>
        {
             { "nw", Direction.NW },
             { "n", Direction.N },
             { "ne", Direction.NE },
             { "sw", Direction.SW },
             { "s", Direction.S },
             { "se", Direction.SE }
        };

        public int X { get; }
        public int Y { get; }

        private Direction(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Direction GetDirection(string direction)
        {
            return _map[direction];
        }
    }
}
