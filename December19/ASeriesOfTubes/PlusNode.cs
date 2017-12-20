using System;
using System.Collections.Generic;

namespace ASeriesOfTubes
{
    public class PlusNode : Node
    {
        public PlusNode(int x, int y) : base(x, y)
        {
        }

        public override Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction direction)
        {
            // when coming from given direction, always continue in different direction
            var dirList = new Dictionary<Direction, Tuple<int, int>>() {
                { Direction.N, Direction.N.NewCoordinates(X, Y) },
                { Direction.E, Direction.E.NewCoordinates(X, Y) },
                { Direction.S, Direction.S.NewCoordinates(X, Y) },
                { Direction.W, Direction.W.NewCoordinates(X, Y) }
            };
            // remove reverse direction from options, we do not go where we came from
            dirList.Remove(direction.Reverse);
            // now take first option for which there exists a valid node
            foreach (var dir in dirList.Keys)
            {
                var newCoords = dirList[dir];
                // try to find node at new position
                var node = nodes.GetNodeAt(newCoords.Item1, newCoords.Item2);
                if (node != null)
                {
                    return Tuple.Create(node, dir);
                }
            }
            throw new Exception($"Unable to determine new node from node {this.X},{this.Y}");
        }
    }
}
