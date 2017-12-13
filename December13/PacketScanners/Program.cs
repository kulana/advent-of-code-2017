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

            var firewalls = firewallGroup.Firewalls.ToList();
            for (int layerIndex = 0; layerIndex < firewalls.Count; layerIndex++)
            {
                // enter firewall with packet
                firewalls[layerIndex].EnterLayer();
                // move all scanners to next position
                firewalls.ForEach(fw => fw.MoveScanner());
            }
            int severity = firewalls.Aggregate(0, (total, fw) =>
                                    total + fw.Severity);
            Console.WriteLine($"The severity is {severity}");
        }
    }
}
