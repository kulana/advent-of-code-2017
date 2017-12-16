using System.Collections.Generic;

namespace PermutationPromenade
{
    class Partner: DanceMove
    {
        private readonly byte _programA;
        private readonly byte _programB;

        public Partner(char programA, char programB)
        {
            _programA = (byte)programA;
            _programB = (byte)programB;
        }

        public override void Perform(IList<byte> input)
        {
            // find positions of programs
            var posA = input.IndexOf(_programA);
            var posB = input.IndexOf(_programB);

            // now that we have the positions, this is a Exchange
            var exchange = new Exchange(posA, posB);
            exchange.Perform(input);
        }
    }
}
