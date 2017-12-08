using System;
using System.Collections.Generic;

namespace IHeardYouLikeRegisters.Conditions
{
    class EvaluatorFactory
    {
        private static readonly Dictionary<string, Func<int, int, bool>> _evalMap = new Dictionary<string, Func<int, int, bool>>
        {
             { "<", (a, b) => a < b },
             { "<=", (a, b) => a <= b },
             { "==", (a, b) => a == b },
             { "!=", (a, b) => a != b },
             { ">", (a, b) => a > b },
             { ">=", (a, b) => a >= b }
        };

        public static Func<int, int, bool> GetEvaluator(string condition)
        {
            return _evalMap[condition];
        }
    }
}
