using Common;
using System;
using System.IO;

namespace IHeardYouLikeRegisters
{
    class Program
    {
        static void Main(string[] args)
        {
            var executionContext = new ExecutionContext();
            var parser = new Parser();

            // Read in lines from file.
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();

            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var instruction = parser.Parse(line);
                executionContext.Execute(instruction);
            });
            Console.WriteLine($"The highest value in any register is {executionContext.HighestValue}");
        }
    }
}
