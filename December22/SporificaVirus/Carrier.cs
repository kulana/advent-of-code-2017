namespace SporificaVirus
{
    public class Carrier
    {
        private readonly Grid _grid;
        private Direction _direction;
        private Position _position;

        public int InfectedCount { get; private set; } = 0;

        public Carrier(Grid grid, Position startPosition, Direction facing)
        {
            _grid = grid;
            _position = startPosition;
            _direction = facing;
        }

        public void VisitCell()
        {
            //get current cell data from grid and determine new direction
            var cell = _grid.GetCell(_position);
            _direction = (cell.Infected) ? _direction.TurnRight() : _direction.TurnLeft();
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
            _position = _direction.Move(_position, _direction);
        }
    }
}
