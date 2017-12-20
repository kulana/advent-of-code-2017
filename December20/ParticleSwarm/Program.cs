using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSwarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            // Read in lines from file.
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            var swarm = new List<Particle>();
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var particle = parser.Parse(line);
                swarm.Add(particle);
            });
        }
    }
}
