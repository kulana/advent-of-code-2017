using System.Collections.Generic;

namespace KnotHash
{
    public class Algorithm<T>
    {
        public void Apply(IList<T> list, IEnumerable<int> lengths, int startPosition)
        {
            int listSize = list.Count;
            var skipSize = 0;
            var currentPosition = startPosition;
            foreach (var length in lengths)
            {
                ReverseCircular(list, currentPosition, length);
                currentPosition = (currentPosition + length + skipSize) % listSize;
                skipSize++;
            }
        }

        /// <summary>
        /// reverses num items in the list, starting from startPos
        /// if the length extends beyond the length of the list, it wraps around to the front
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private void ReverseCircular(IList<T> list, int index, int count)
        {
            int listSize = list.Count;
            if (count > listSize)
            {
                return;
            }

            // determine values in sublist
            List<T> subList = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                int actualIndex = (index + i) % listSize;
                subList.Add(list[actualIndex]);
            }
            // reverse sublist
            subList.Reverse();
            // place sublist items back in original list
            for (int i = 0; i < count; i++)
            {
                int actualIndex = (index + i) % listSize;
                list[actualIndex] = subList[i];
            }
        }
    }
}
