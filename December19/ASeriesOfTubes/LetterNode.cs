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

        public override string ToString()
        {
            return Letter.ToString();
        }
    }
}
