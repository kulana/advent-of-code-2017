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
            var firewallGroup = LoadFirewalls();
            var caught = false;
            do
            {
                firewallGroup.Visit();
                caught = firewallGroup.IsCaught;
            }
            while (caught);
        }

        static FirewallGroup LoadFirewalls()
        {
            var parser = new Parser();
            var firewallGroup = new FirewallGroup();

            var filePath = Directory.GetCurrentDirectory() + "/test.txt";
            var fileProcessor = new FileProcessor();
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                firewallGroup.Add(Parser.Parse(line));
            });
            return firewallGroup;
        }
    }
}
