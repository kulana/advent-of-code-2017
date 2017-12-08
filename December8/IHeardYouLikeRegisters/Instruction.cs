using IHeardYouLikeRegisters.Conditions;
using IHeardYouLikeRegisters.Operations;

namespace IHeardYouLikeRegisters
{
    class Instruction
    {
        public Operation Operation { get; set; }
        public Condition Condition { get; set; }

        public void Execute(ExecutionContext context)
        {
            if (Condition.Test(context))
            {
                Operation.Perform(context);
            }
        }
    }
}
