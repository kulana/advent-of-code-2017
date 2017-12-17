using System;

namespace SpinLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorithm = new SpinLockAlgorithm(367);
            Console.Write($"{algorithm.GetSolutionPart1(2017)}");
        }
    }
}
