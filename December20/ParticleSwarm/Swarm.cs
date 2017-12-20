using System;
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
            ProcessCollisions();
        }

        private void ProcessCollisions()
        {
            // create space using xyz coordinates of particles
            // insert particles one by one
            // if an insert cannot take place because the key is already taken, set both to destroyed
            var space = new Dictionary<string, Particle>();
            foreach (var particle in _particles.Where(p => p.IsAlive))
            {
                var key = particle.GetKey();
                if (space.ContainsKey(key))
                {
                    // set particle to destroyed
                    particle.IsAlive = false;
                    space[key].IsAlive = false;
                }
                else
                {
                    // insert particle in space
                    space[key] = particle;
                }
            } 
        }

        public ICollection<Particle> Particles(Func<Particle, bool> filter)
        {
            return _particles.Where(filter).ToList();
        }

        public Particle Closest()
        {
            return _particles.Aggregate((minItem, nextItem) => minItem.ManhattanDistance < nextItem.ManhattanDistance ? minItem : nextItem);
        }
    }
}
