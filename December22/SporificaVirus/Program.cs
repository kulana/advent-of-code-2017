using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporificaVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = InitializeGrid();
            var carrier = new Carrier(grid, grid.Center(), Direction.N);
            for (int step = 1; step <= 10000; step++)
            {
                carrier.VisitCell();
                carrier.MoveForward();
            }
            Console.WriteLine($"Number of cells infected = {carrier.InfectedCount}");
        }

        private static Grid InitializeGrid()
        {
            // load initial grid
            var parser = new Parser();

            // Read in lines from file.
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            var grid = new Grid();
            int yPosition = 0;
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                parser.Parse(grid, yPosition, line);
                yPosition++;
            });
            return grid;
        }
    }
}
