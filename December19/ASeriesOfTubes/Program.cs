using Common;
using System;
using System.IO;

namespace ASeriesOfTubes
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            var nodes = new LinkedNodes();
            var parser = new Parser(nodes);

            int lineNumber = 1; 
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                parser.Parse(lineNumber, line);
                lineNumber++;
            });

            // now that have read the entire structure, try to find the way through the grid
            Console.WriteLine(nodes.Visit(Direction.S));
        }
    }
}
