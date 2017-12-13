using System;
using System.Collections.Generic;
using System.Linq;

namespace PacketScanners
{
    class FirewallGroup : IFirewall
    {
        private List<IFirewall> _firewalls = new List<IFirewall>();
        private int _previousDepth = 0;
        private int _layerIndex = 0;

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

        public void MoveScanner()
        {
            _firewalls.ForEach(fw => fw.MoveScanner());
        }

        public void Visit()
        {
            for (int layerIndex = 0; layerIndex < _firewalls.Count; layerIndex++)
            {
                // enter firewall with packet
                _firewalls[layerIndex].Visit();
                // move all scanners to next position
                MoveScanner();
            }
        }

        public IList<IFirewall> Firewalls => _firewalls;
    }
}
