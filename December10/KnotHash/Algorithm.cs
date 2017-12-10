using KnotHash.Extensions;
using System.Collections.Generic;

namespace KnotHash
{
    public class Algorithm
    {
        public void Apply<T>(IList<T> list, IEnumerable<int> lengths, int startPosition)
        {
            int listSize = list.Count;
            var skipSize = 0;
            var currentPosition = startPosition;
            foreach (var length in lengths)
            {
                list.ReverseCircular(currentPosition, length);
                currentPosition = (currentPosition + length + skipSize) % listSize;
                skipSize++;
            }
        }
    }
}
