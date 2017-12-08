using System;
using System.Collections.Generic;

namespace IHeardYouLikeRegisters.Operations
{
    class OperationsFactory
    {
        private static readonly Dictionary<string, Func<Operation>> OperationsMap = new Dictionary<string, Func<Operation>>
        {
             { "inc", () => new IncOperation()},
             { "dec", () => new DecOperation()}
        };

        public static Operation GetOperator(string @operator)
        {
            var func = OperationsMap[@operator];
            return func();
        }
    }
}
