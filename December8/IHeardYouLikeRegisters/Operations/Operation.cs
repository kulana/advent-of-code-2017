using System;

namespace IHeardYouLikeRegisters.Operations
{
    public class Operation
    {
        public string Variable { get; set; }
        public Func<int, int, int> Operand { get; set; }
        public int Value { get; set; }

        public void Perform(ExecutionContext context)
        {
            int currValue = context.GetValue(this.Variable);
            context.SetValue(this.Variable, Operand(currValue, this.Value));
        }
    }
}
