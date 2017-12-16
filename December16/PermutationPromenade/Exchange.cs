using System.Collections.Generic;

namespace PermutationPromenade
{
    class Exchange: DanceMove
    {
        private readonly int _a;
        private readonly int _b;

        public Exchange(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public override void Perform(IList<byte> input)
        {
            var posAChar = input[_a];
            var posBChar = input[_b];
            input[_a] = posBChar;
            input[_b] = posAChar;
        }
    }
}
