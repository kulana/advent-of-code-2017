using Common;
using System.Collections.Generic;
using System.IO;

namespace FractalArt
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            // Read in lines from file.
            var filePath = Directory.GetCurrentDirectory() + "/rules.txt";
            var fileProcessor = new FileProcessor();
            var rules = new List<EnhancementRule>();
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var rule = parser.Parse(line);
                rules.Add(rule);
            });
        }
    }
}
