using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalArt
{
    public class Algorithm
    {
        private readonly IList<EnhancementRule> _rules;

        public Algorithm(IList<EnhancementRule> rules)
        {
            _rules = rules;
        }

        public Square Apply(Square originalSquare)
        {
            var subSquareDimension = (originalSquare.Dimension % 2 == 0) ? 2 : 3;
            IList<Square> subSquares = originalSquare.Divide(subSquareDimension);
            IList<Square> converted = new List<Square>();
            for (int i = 0; i < subSquares.Count; i++)
            {
                var subSquare = subSquares[i];
                var rule = _rules.Where(r => r.IsApplicableTo(subSquare)).FirstOrDefault(r => r.IsMatch(subSquare));
                if (rule != null)
                {
                    // replace subsquare by the rule conversion output
                    converted.Add(rule.GetConversion());
                }
            }
            // combine subsquares back into 1 square
            return new SquareCombiner(converted).Join();
        }
    }
}
