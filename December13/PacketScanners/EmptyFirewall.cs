using System;

namespace PacketScanners
{
    class EmptyFirewall : IFirewall, ICloneable<IFirewall>
    {
        private static EmptyFirewall _instance = new EmptyFirewall();

        public int Severity => 0;
        public bool IsCaught => false;

        public override string ToString()
        {
            return "EmptyFirewall";
        }

        public void MoveScanner() { }
        public void Visit() { }

        public IFirewall Clone() => _instance;

        public static IFirewall Instance => _instance;
    }
}
