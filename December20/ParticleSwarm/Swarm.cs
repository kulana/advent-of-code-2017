using System.Collections.Generic;
using System.Linq;

namespace ParticleSwarm
{
    public class Swarm
    {
        private readonly List<Particle> _particles = new List<Particle>();

        public void Add(Particle particle)
        {
            _particles.Add(particle);
        }

        public void Tick()
        {
            _particles.ForEach(p => p.Tick());
        }

        public Particle Closest()
        {
            return _particles.Aggregate((minItem, nextItem) => minItem.ManhattanDistance < nextItem.ManhattanDistance ? minItem : nextItem);
        }
    }
}
