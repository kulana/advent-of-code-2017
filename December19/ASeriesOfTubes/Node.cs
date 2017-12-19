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

        public abstract Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction Direction);

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
