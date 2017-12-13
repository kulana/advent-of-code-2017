namespace PacketScanners
{
    class Firewall: IFirewall
    {
        public int Depth { get; private set; }
        public int Range { get; private set; }

        private int _scannerPosition;
        private Direction _scannerDirection;
        private bool _hit = false;

        public Firewall(int depth, int range)
        {
            Depth = depth;
            Range = range;
            _scannerPosition = 1;
            _scannerDirection = Direction.Down;
        } 

        // a visit means the packat is in the firewall (at position 1)
        public void Visit()
        {
            _hit = (_scannerPosition == 1);
        }

        public int Severity => _hit ? (Range * Depth) : 0;

        public override string ToString()
        {
            return $"Range={Range}, Direction={_scannerDirection}, ScannerPosition={_scannerPosition}";
        }

        // move scanner,
        // ugly logic here, there must be a more elegant way?
        public void MoveScanner()
        {
            if (_scannerDirection == Direction.Down)
            {
                if (_scannerPosition < Range)
                {
                    _scannerPosition++;
                    return;
                }
                else
                {
                    _scannerPosition--;
                    _scannerDirection = Direction.Up;
                }
            }
            else
            {
                if (_scannerPosition > 1)
                {
                    _scannerPosition--;
                    return;
                }
                else
                {
                    _scannerPosition++;
                    _scannerDirection = Direction.Down;
                }
            }
        }
    }

    class Direction
    {
        public static Direction Up = new Direction("UP");
        public static Direction Down = new Direction("DOWN");

        private readonly string _value;

        private Direction(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
