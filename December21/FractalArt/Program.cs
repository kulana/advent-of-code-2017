using Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace FractalArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in lines from file.
            var rulesPath = Directory.GetCurrentDirectory() + "/rules.txt";
            var fileProcessor = new FileProcessor();
            var rules = new List<EnhancementRule>();
            var ruleParser = new RuleParser();
            fileProcessor.ReadFilePerLine(rulesPath, (line) =>
            {
                var rule = ruleParser.Parse(line);
                rules.Add(rule);
            });

            // read initial pattern
            var patternPath = Directory.GetCurrentDirectory() + "/initialPattern.txt";
            var pattern = fileProcessor.ReadFileToEnd(patternPath).Replace("\r\n", "/");
            var square = new Square(pattern);

            // execute program
            var algorithm = new Algorithm(rules);
            int i = 0;
            while (i < 5)
            {
                square = algorithm.Apply(square);
                i++;
            }
            Console.WriteLine($"Number of pixels on after {i} iterations = {square.PixelsOn}");
        }
    }
}
