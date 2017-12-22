namespace SporificaVirus
{
    public class Carrier
    {
        private readonly Grid _grid;
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }
        public Direction Facing { get; private set; }

        public int InfectedCount { get; private set; }

        public Carrier(Grid grid, Position startPosition, Direction facing)
        {
            _grid = grid;
            Position = startPosition;
            Direction = facing;
            InfectedCount = 0;
        }
    }
}
