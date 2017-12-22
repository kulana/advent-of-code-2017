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

        }
    }
}
