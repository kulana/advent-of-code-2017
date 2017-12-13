using Common;
using System;
using System.IO;

namespace HexEd
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            var moves = fileProcessor.ReadFileToEnd(filePath).Split(',');
            var position = new Position(0, 0);
            foreach (var move in moves)
            {
                position.Move(Direction.GetDirection(move));
            }
            Console.WriteLine($"Minimum steps necessary to get to {position} = {position.DetermineMinimumStepsFrom(new Position(0, 0))}");
            Console.WriteLine($"Furthest away = {position.MaxNumberOfSteps}");
        }
    }
}
