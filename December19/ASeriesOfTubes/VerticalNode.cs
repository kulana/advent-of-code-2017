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
            var newCoords = direction.NewCoordinates(X, Y);
            return Tuple.Create(nodes.GetNodeAt(newCoords.Item1, newCoords.Item2), direction);
        }
    }
}
