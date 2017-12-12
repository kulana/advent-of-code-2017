using System.Collections.Generic;

namespace DigitalPlumber
{
    class Parser
    {
        public static ConnectionDefinition Parse(string input)
        {
            var tokens = input.Replace("<->", "|").Split('|');
            var from = int.Parse(tokens[0]);
            var toList = new List<int>();
            foreach (var value in tokens[1].Split(','))
            {
                toList.Add(int.Parse(value));
            }
            return new ConnectionDefinition
            {
                From = from,
                To = toList
            };
        }
    }
}
