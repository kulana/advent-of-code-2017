using System;

namespace ASeriesOfTubes
{
    public abstract class Node
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction direction)
        {
            var newCoords = direction.NewCoordinates(X, Y);
            return Tuple.Create(nodes.GetNodeAt(newCoords.Item1, newCoords.Item2), direction);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
