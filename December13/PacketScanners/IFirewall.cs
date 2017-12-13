namespace PacketScanners
{
    interface IFirewall
    {
        int Severity { get; }
        void MoveScanner();
        void Visit();
        bool IsCaught { get; }
        IFirewall Clone();
    }
}
