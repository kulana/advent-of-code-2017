using System.Text.RegularExpressions;

namespace ParticleSwarm
{
    public class Parser
    {
        private const string Pattern = @"\w=<(?<x>-?\d+),(?<y>-?\d+),(?<z>-?\d+)>";

        public Particle Parse(string line)
        {
            MatchCollection matches = Regex.Matches(line, Pattern, RegexOptions.IgnorePatternWhitespace);
            return new Particle(GetSpecs(matches[0].Groups), GetSpecs(matches[1].Groups), GetSpecs(matches[2].Groups));
        }

        private Specs3D GetSpecs(GroupCollection values)
        {
            return new Specs3D
            {
                X = int.Parse(values["x"].Value),
                Y = int.Parse(values["y"].Value),
                Z = int.Parse(values["z"].Value)
            };
        }
    }
}
