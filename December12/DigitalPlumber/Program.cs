using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPlumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in lines from file.
            var fileProcessor = new FileProcessor();
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var graph = new ConnectionGraph();
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var connectionInfo = Parser.Parse(line);
                graph.AddConnection(connectionInfo);
            });

            // first part of puzzle
            var reachableNodes = graph.GetReachableNodesFor(0);
            Console.WriteLine($"Reachable groups for group 0 is {reachableNodes.Count}");

            // second part of puzzle
            var groups = graph.GetNumberOfGroups();
            Console.WriteLine($"Total number of groups is {groups}");
        }
    }
}
