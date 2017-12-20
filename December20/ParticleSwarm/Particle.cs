using System;

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

        public int ManhattanDistance => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
    }
}
