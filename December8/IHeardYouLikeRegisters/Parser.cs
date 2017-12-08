using IHeardYouLikeRegisters.Conditions;
using IHeardYouLikeRegisters.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHeardYouLikeRegisters
{
    class Parser
    {
        /// <summary>
        /// Split input string into an expression and a condition
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>

        public Instruction Parse(string input)
        {
            var tokens = input.Split(' ');
            var operation = new Operation()
            {
                Variable = tokens[0],
                Operand = OperationsFactory.GetOperator(tokens[1]),
                Value = int.Parse(tokens[2])
            };

            var cond = new Condition()
            {
                Variable = tokens[4],
                Evaluator = EvaluatorFactory.GetEvaluator(tokens[5]),
                Value = int.Parse(tokens[6])
            };
            return new Instruction
            {
                Operation = operation,
                Condition = cond
            };
        }
    }
}
