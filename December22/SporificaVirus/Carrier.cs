namespace SporificaVirus
{
    public class Carrier
    {
        private readonly Grid _grid;
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        public int InfectedCount { get; private set; }

        public Carrier(Grid grid, Position startPosition, Direction facing)
        {
            _grid = grid;
            Position = startPosition;
            Direction = facing;
            InfectedCount = 0;
        }

        public void VisitCell()
        {
            //get current cell data from grid
            var cell = _grid.GetCell(this.Position);
            var newDirection = (cell.Infected) ? Direction.TurnRight() : Direction.TurnLeft();
            Direction = newDirection;
            if (!cell.Infected)
            {
                cell.Infected = true;
                InfectedCount++;
            }
            else
            {
                cell.Infected = false;
            }
        }

        public void MoveForward()
        {
            Position = Direction.Move(this.Position, this.Direction);
        }
    }
}
