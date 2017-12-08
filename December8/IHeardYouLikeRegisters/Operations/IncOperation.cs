namespace IHeardYouLikeRegisters.Operations
{
    class IncOperation : Operation
    {
        public override void Perform(ExecutionContext context)
        {
            int currValue = context.GetValue(this.Variable);
            context.SetValue(this.Variable, currValue + this.Value);
        }

    }
}
