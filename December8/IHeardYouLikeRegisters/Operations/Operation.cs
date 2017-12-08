namespace IHeardYouLikeRegisters.Operations
{
    abstract class Operation
    {
        public string Variable { get; set; }
        public int Value { get; set; }

        public abstract void Perform(ExecutionContext context); 
    }
}
