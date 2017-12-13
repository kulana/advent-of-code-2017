namespace PacketScanners
{
    class EmptyFirewall : IFirewall
    {
        public int Severity => 0;

        public override string ToString()
        {
            return "EmptyFirewall";
        }

        public void MoveScanner() { }

        public void EnterLayer() { }
    }
}
