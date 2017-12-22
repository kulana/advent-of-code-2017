using System;
using System.Collections.Generic;
using System.Linq;

namespace SporificaVirus
{
    public sealed class Direction
    {
        public static Direction N = new Direction("N", (p) => new Position(p.X, p.Y - 1));
        public static Direction E = new Direction("E", (p) => new Position(p.X + 1, p.Y));
        public static Direction S = new Direction("S", (p) => new Position(p.X, p.Y + 1));
        public static Direction W = new Direction("W", (p) => new Position(p.X - 1, p.Y));

        private static IList<Direction> _directions = new List<Direction>()
        {
            Direction.N, Direction.E, Direction.S, Direction.W
        };

        private static IDictionary<Direction, Direction> _reverseMapping = new Dictionary<Direction, Direction>()
        {
            {Direction.N, Direction.S },
            {Direction.E, Direction.W },
            {Direction.S, Direction.N },
            {Direction.W, Direction.E },
        };

        private string Title { get; }
        private Func<Position, Position> MoveFunction { get; }

        private Direction(string title, Func<Position, Position> moveFunction)
        {
            Title = title;
            MoveFunction = moveFunction;
        }

        public Direction Reverse => _reverseMapping[this];

        public Position Move(Position fromPosition)
        {
            return this.MoveFunction(fromPosition);
        }

        public Direction TurnLeft()
        {
            int current = _directions.IndexOf(this);
            if (current == 0) {
                return _directions.Last();
            }
            return _directions[--current];
        }

        public Direction TurnRight()
        {
            int current = _directions.IndexOf(this);
            if (current == _directions.Count-1)
            {
                return _directions.First();
            }
            return _directions[++current];
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Direction);
        }

        public bool Equals(Direction obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.Title.Equals(obj.Title);
        }

    }
}
