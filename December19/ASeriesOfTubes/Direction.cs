using System;
using System.Collections.Generic;

namespace ASeriesOfTubes
{
    public sealed class Direction
    {
        public static Direction N = new Direction("N", (x, y) => Tuple.Create(x, y - 1));
        public static Direction E = new Direction("E", (x, y) => Tuple.Create(x + 1, y));
        public static Direction S = new Direction("S", (x, y) => Tuple.Create(x, y + 1));
        public static Direction W = new Direction("W", (x, y) => Tuple.Create(x - 1, y));

        private static IDictionary<Direction, Direction> _reverseMap = new Dictionary<Direction, Direction>()
        {
            {Direction.N, Direction.S },
            {Direction.E, Direction.W },
            {Direction.S, Direction.N },
            {Direction.W, Direction.E },
        };

        private string Title { get; }
        private Func<int, int, Tuple<int, int>> CoordinatesFunc { get; }

        private Direction(string title, Func<int, int, Tuple<int, int>> coordinatesFunc)
        {
            Title = title;
            CoordinatesFunc = coordinatesFunc;
        }

        public Direction Reverse()
        {
            return _reverseMap[this];
        }

        public Tuple<int, int> NewCoordinates(int x, int y)
        {
            return CoordinatesFunc(x, y);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Direction);
        }

        private bool Equals(Direction obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.Title.Equals(Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}
