using Common;
using System;
using System.IO;

using System.Linq;

namespace PacketScanners
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            var firewallGroup = new FirewallGroup();

            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                firewallGroup.Add(Parser.Parse(line));
            });

            // by visiting the group, we set the process in motion visiting all layers and moving the scanner
            firewallGroup.Visit();
            Console.WriteLine($"The severity is {firewallGroup.Severity}");
        }
    }
}
