using System.Collections.Generic;

namespace PermutationPromenade
{
    class Spin : DanceMove
    {
        private readonly int _numChars;

        public Spin(int numChars)
        {
            _numChars = numChars;
        }

        public override void Perform(IList<byte> input)
        {
            // determine values in sublist
            var subList = new List<byte>(_numChars);
            var startIndex = input.Count - _numChars;
            for (int i = 0; i < _numChars; i++)
            {
                var value = input[startIndex + i];
                input.RemoveAt(startIndex + i);
                input.Insert(i, value);
            }
        }
    }
}
