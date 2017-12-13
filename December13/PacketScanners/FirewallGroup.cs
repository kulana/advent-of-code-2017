using System;
using System.Collections.Generic;
using System.Linq;

namespace PacketScanners
{
    class FirewallGroup
    {
        private List<IFirewall> _firewalls = new List<IFirewall>();
        private int _previousDepth = 0;
        private int _delay = 0;

        public int Severity => _firewalls.Aggregate(0, (total, fw) =>
                                    total + fw.Severity);

        public void Add(Firewall firewall)
        {
            int emptyFirewalls = Math.Max(0, firewall.Depth - _previousDepth - 1);
            // create empty firewall(s)
            for (int i = 0; i < emptyFirewalls; i++)
            {
                _firewalls.Add(new EmptyFirewall());
            }
            _firewalls.Add(firewall);
            _previousDepth = firewall.Depth;
        }

        private void AddDelay()
        {
            _delay++;
            MoveScanner();
        }

        public void MoveScanner()
        {
            _firewalls.ForEach(fw => fw.MoveScanner());
        }

        public void Visit()
        {
            IsCaught = false;
            do
            {
                // copy original firewalls as seed for the next run
                var originalFirewalls = new List<IFirewall>();
                foreach (var fw in _firewalls)
                {
                    originalFirewalls.Add(fw.Clone());
                }
                for (int layerIndex = 0; layerIndex < _firewalls.Count; layerIndex++)
                {
                    // enter firewall with packet
                    _firewalls[layerIndex].Visit();
                    // move all scanners to next position
                    MoveScanner();
                }
                IsCaught = _firewalls.Any(fw => fw.IsCaught);
                Console.WriteLine($"Using delay {Delay}, severity is {Severity}, caught = {IsCaught}");
                _firewalls = originalFirewalls;
                AddDelay(); // add 1 picosecond delay to previous firewalls
            }
            while (IsCaught);
        }

        public bool IsCaught { get; private set; }
        public int Delay => _delay;
    }
}
