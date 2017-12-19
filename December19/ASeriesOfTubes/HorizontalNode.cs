using System;

namespace ASeriesOfTubes
{
    public class HorizontalNode : Node
    {
        public HorizontalNode(int x, int y) : base(x, y)
        {
        }

        public override Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction direction)
        {
            if (direction == Direction.E || direction == Direction.W)
            {
                var horizontalCoordinates = direction.NewCoordinates(X, Y);
                return Tuple.Create(nodes.GetNodeAt(horizontalCoordinates.Item1, horizontalCoordinates.Item2), direction);
            }
            // otherwise, continue in same direction
            var verticalCoordinates = direction.NewCoordinates(X, Y);
            return Tuple.Create(nodes.GetNodeAt(verticalCoordinates.Item1, verticalCoordinates.Item2), direction);

        }
    }
}
