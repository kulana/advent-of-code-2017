using System;
using System.Collections.Generic;

namespace ASeriesOfTubes
{
    public class VerticalNode : Node
    {
        public VerticalNode(int x, int y): base(x, y)
        {
        }

        public override Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction direction)
        {
            if (direction == Direction.N || direction == Direction.S)
            {
                var verticalCoordinates = direction.NewCoordinates(X, Y);
                return Tuple.Create(nodes.GetNodeAt(verticalCoordinates.Item1, verticalCoordinates.Item2), direction);
            }
            var horizontalCoordinates = direction.NewCoordinates(X, Y);
            return Tuple.Create(nodes.GetNodeAt(horizontalCoordinates.Item1, horizontalCoordinates.Item2), direction);
        }
    }
}
