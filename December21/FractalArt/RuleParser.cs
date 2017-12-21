using System.Text.RegularExpressions;

namespace FractalArt
{
    public class RuleParser
    {
        private const string Pattern = @"(?<matchPattern>[.#\/]+) => (?<conversionPattern>[.#\/]+)";

        public EnhancementRule Parse(string line)
        {
            MatchCollection matches = Regex.Matches(line, Pattern);
            return CreateRule(matches[0].Groups);
        }

        private EnhancementRule CreateRule(GroupCollection groups)
        {
            var match = new Square(groups["matchPattern"].Value);
            var conversion = new Square(groups["conversionPattern"].Value);
            return new EnhancementRule(match, conversion);
        }
    }
}
