using System;
using System.Collections.Generic;

namespace IHeardYouLikeRegisters.Operations
{
    class OperationsFactory
    {
        private static readonly Dictionary<string, Func<int, int, int>> OperationsMap = new Dictionary<string, Func<int, int, int>>
        {
             { "inc", (a, b) => a + b },
             { "dec", (a, b) => a - b }
        };

        public static Func<int, int, int> GetOperator(string @operator)
        {
            return OperationsMap[@operator];
        }
    }
}
