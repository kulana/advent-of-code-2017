using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSwarm
{
    public class Particle
    {
        public Specs3D Position { get; set; }
        public Specs3D Velocity { get; set; }
        public Specs3D Acceleration { get; set; }

        public Particle(Specs3D position, Specs3D velocity, Specs3D acceleration)
        {
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }
    }
}
