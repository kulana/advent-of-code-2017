using System.Collections.Generic;

namespace KnotHash.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// reverses num items in the list, starting from startPos
        /// if the length extends beyond the length of the list, it wraps around to the front
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IList<T> ReverseCircular<T>(this IList<T> list, int index, int count)
        {
            int listSize = list.Count;
            if (count > listSize)
            {
                return list;
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
            return list;
        }
    }
}
