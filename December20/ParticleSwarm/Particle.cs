using System;

namespace ParticleSwarm
{
    public  class Particle
    {
        public int Id { get; private set; }
        public Specs3D Position { get; set; }
        public Specs3D Velocity { get; set; }
        public Specs3D Acceleration { get; set; }

        public Particle(int id, Specs3D position, Specs3D velocity, Specs3D acceleration)
        {
            Id = id;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        //Increase the X velocity by the X acceleration.
        //Increase the Y velocity by the Y acceleration.
        //Increase the Z velocity by the Z acceleration.
        //Increase the X position by the X velocity.
        //Increase the Y position by the Y velocity.
        //Increase the Z position by the Z velocity.
        public void Tick()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;
            Velocity.Z += Acceleration.Z;

            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }

        public int ManhattanDistance => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);

        public override bool Equals(object obj)
        {
            return Equals(obj as Particle);
        }

        public bool Equals(Particle obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.Id == obj.Id;
        }
    }
}
