using System;
using System.Collections.Generic;

namespace SporificaVirus
{
    public sealed class Direction
    {
        public static Direction N = new Direction((p) => new Position(p.X, p.Y - 1));
        public static Direction E = new Direction((p) => new Position(p.X + 1, p.Y));
        public static Direction S = new Direction((p) => new Position(p.X, p.Y + 1));
        public static Direction W = new Direction((p) => new Position(p.X - 1, p.Y));

        private IList<Direction> _directions = new List<Direction>()
        {
            Direction.N, Direction.E, Direction.S, Direction.W
        };

        private Func<Position, Position> MoveFunction { get; }

        private Direction(Func<Position, Position> moveFunction)
        {
            MoveFunction = moveFunction;
        }

        public Position Move(Position fromPosition, Direction direction)
        {
            return direction.MoveFunction(fromPosition);
        }

        public Direction TurnLeft()
        {
            int current = _directions.IndexOf(this);
            if (current == 0) {
                current = _directions.Count;
            }
            return _directions[--current];
        }

        public Direction TurnRight()
        {
            int current = _directions.IndexOf(this);
            if (current == _directions.Count-1)
            {
                current = 0;
            }
            return _directions[++current];
        }
    }
}
