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
            var swarm = new Swarm();
            int particleIndex = 0;
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var particle = parser.Parse(particleIndex, line);
                swarm.Add(particle);
                particleIndex++;
            });

            var closestParticle = swarm.Closest();
            int tick = 0;
            int noChangeCounter = 0;
            while (noChangeCounter < 1000)
            {
                swarm.Tick();
                var newClosest = swarm.Closest();
                if (closestParticle.Equals(newClosest))
                {
                    noChangeCounter++;
                }
                else
                {
                    noChangeCounter = 0;
                    closestParticle = newClosest;
                }
                tick++;
            }
            Console.WriteLine($"Closest particle is {closestParticle.Id} after {tick} ticks");
        }
    }
}
