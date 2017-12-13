using System;

namespace PacketScanners
{
    class Firewall: IFirewall, ICloneable<IFirewall>
    {
        public int Depth { get; private set; }
        public int Range { get; private set; }
        public int ScannerPosition { get; private set; }
        public Direction ScannerDirection { get; private set; }

        private bool _hit = false;

        public Firewall(int depth, int range)
        {
            Depth = depth;
            Range = range;
            ScannerPosition = 1;
            ScannerDirection = Direction.Down;
        }

        public Firewall(int depth, int range, int scannerPosition, Direction scannerDirection) : this(depth, range)
        {
            ScannerPosition = scannerPosition;
            ScannerDirection = scannerDirection;
        } 

        // a visit means the package is in the firewall at position 1
        public void Visit()
        {
            _hit = (ScannerPosition == 1);
        }

        public int Severity => _hit ? (Range * Depth) : 0;

        public bool IsCaught => _hit;

        public override string ToString()
        {
            return $"Range={Range}, Direction={ScannerDirection}, ScannerPosition={ScannerPosition}";
        }

        // move scanner,
        // ugly logic here, there must be a more elegant way?
        public void MoveScanner()
        {
            if (ScannerDirection == Direction.Down)
            {
                if (ScannerPosition < Range)
                {
                    ScannerPosition++;
                }
                else
                {
                    ScannerPosition--;
                    ScannerDirection = Direction.Up;
                }
            }
            else
            {
                if (ScannerPosition > 1)
                {
                    ScannerPosition--;
                }
                else
                {
                    ScannerPosition++;
                    ScannerDirection = Direction.Down;
                }
            }
        }

        public IFirewall Clone()
        {
            return new Firewall(Depth, Range, ScannerPosition, ScannerDirection);
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
