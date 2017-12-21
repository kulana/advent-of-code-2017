using System;

namespace FractalArt
{
    public class EnhancementRule
    {
        private readonly Square _match;
        private readonly Square _conversion;

        public EnhancementRule(Square match, Square conversion)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            _match = match;
            _conversion = conversion;
        }

        public bool IsMatch(Square square)
        {
            // check if the square, rotated or flipped, matches the current rule
            return true;
        }

        public bool IsApplicable(int forSize) => (forSize == _match.Size);

    }
}
