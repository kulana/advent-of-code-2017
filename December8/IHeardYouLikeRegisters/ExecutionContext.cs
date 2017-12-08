using System.Collections.Generic;
using System.Linq;

namespace IHeardYouLikeRegisters
{
    public class ExecutionContext
    {
        private readonly Dictionary<string, int> _context = new Dictionary<string, int>();

        public void Execute(Instruction instruction)
        {
            instruction.Execute(this);
        }

        public int GetValue(string variable)
        {
            if (_context.ContainsKey(variable))
            {
                return _context[variable];
            }
            return 0;
        }

        public void SetValue(string variable, int value)
        {
            _context[variable] = value;
        }

        public int HighestValue =>  _context.Values.Max();
    }
}
