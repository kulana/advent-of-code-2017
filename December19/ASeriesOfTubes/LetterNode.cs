using System;

namespace ASeriesOfTubes
{
    public class LetterNode : Node
    {
        public char Letter { get; private set; }

        public LetterNode(int x, int y, char letter): base(x, y)
        {
            Letter = letter;
        }

        public override Tuple<Node, Direction> GetNextNode(LinkedNodes nodes, Direction direction)
        {
            var newCoords = direction.NewCoordinates(X, Y);
            return Tuple.Create(nodes.GetNodeAt(newCoords.Item1, newCoords.Item2), direction);
        }

        public override string ToString()
        {
            return Letter.ToString();
        }
    }
}
