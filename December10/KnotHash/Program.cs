using System;
using System.Collections.Generic;
using System.Linq;

namespace KnotHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 256).ToList();
            var algorithm = new Algorithm();
            var lengths = new List<int>() { 197, 97, 204, 108, 1, 29, 5, 71, 0, 50, 2, 255, 248, 78, 254, 63 };
            algorithm.Apply(list, lengths, 0);
            Console.WriteLine($"The answer is {list[0] * list[1]}");
        }
    }
}
