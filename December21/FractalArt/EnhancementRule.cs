using System;

namespace FractalArt
{
    public class EnhancementRule
    {
        private readonly string _match;
        private readonly string _conversion;

        public EnhancementRule(string match, string conversion)
        {
            _match = match;
            _conversion = conversion;
        }

        public bool IsMatch(Square square)
        {
            // check if the square, rotated or flipped, matches the current rule
            return (square.Matches(_match));
        }

        public Square Conversion => new Square(_conversion);
    }
}
