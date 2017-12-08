using System;

namespace IHeardYouLikeRegisters.Conditions
{
    public class Condition
    {
        public string Variable { get; set; }
        public Func<int, int, bool> Evaluator { get; set; }
        public int Value { get; set; }

        public bool Test(ExecutionContext context)
        {
            int variableValue = context.GetValue(this.Variable);
            return Evaluator(variableValue, this.Value);
        }
    }
}
