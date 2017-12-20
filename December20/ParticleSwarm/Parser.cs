namespace ParticleSwarm
{
    public class Parser
    {
        public Particle Parse(string line)
        {
            var parts = line.Split(',');
            var position = GetSpecs(parts[0]);
            var velocity = GetSpecs(parts[1]);
            var acceleration = GetSpecs(parts[2]);
            return new Particle(position, velocity, acceleration);
        }

        // can parse a value like p=<-717,-4557,2578>
        private Specs3D GetSpecs(string input)
        {
            var parts = input.Split('=');
            // remove first and last characters
            var rawValues = parts[1].TrimStart('<').TrimEnd('>');
            var values = rawValues.Split(',');
            return new Specs3D
            {
                X = int.Parse(values[0]),
                Y = int.Parse(values[1]),
                Z = int.Parse(values[2])
            };
        }
    }
}
