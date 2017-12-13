namespace PacketScanners
{
    class Parser
    {
        public static Firewall Parse(string input)
        {
            var tokens = input.Split(':');
            var depth = int.Parse(tokens[0].Trim(' '));
            var range = int.Parse(tokens[1].Trim(' '));
            return new Firewall(depth, range);
        }
    }
}
