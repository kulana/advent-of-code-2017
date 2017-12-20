using System.Text.RegularExpressions;

namespace ParticleSwarm
{
    public class Parser
    {
        private const string Pattern = @"\w=<(?<x>-?\d+),(?<y>-?\d+),(?<z>-?\d+)>";

        // paser p=<-717,-4557,2578>, v=<153,21,30>, a=<-8,8,-7>
        public Particle Parse(string line)
        {
            MatchCollection matches = Regex.Matches(line, Pattern, RegexOptions.IgnorePatternWhitespace);
            return new Particle(GetSpecs(matches[0].Groups), GetSpecs(matches[1].Groups), GetSpecs(matches[2].Groups));
        }

        // can parse a value like p=<-717,-4557,2578>
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
