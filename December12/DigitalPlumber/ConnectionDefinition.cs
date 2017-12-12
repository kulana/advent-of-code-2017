using System.Collections.Generic;

namespace DigitalPlumber
{
    class ConnectionDefinition
    {
        public int From { get; set; }
        public IList<int> To { get; set; }
    }
}
