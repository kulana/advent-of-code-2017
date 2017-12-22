using System;

namespace SporificaVirus
{
    public class Carrier
    {
        private readonly Grid _grid;
        private Direction _currentDirection;
        private Position _position;
        private readonly IDirectionStrategy _directionStrategy;

        public int InfectedCount { get; private set; } = 0;

        public Carrier(Grid grid, Position startPosition, Direction facing, IDirectionStrategy directionStrategy)
        {
            _grid = grid;
            _position = startPosition;
            _currentDirection = facing;
            _directionStrategy = directionStrategy;
        }

        public void VisitCell()
        {
            //get current cell data from grid and determine new direction
            var cell = _grid.GetCell(_position);
            _currentDirection = _directionStrategy.NewDirection(cell, _currentDirection);
            cell.State.Change();
            if (cell.State.IsInfected)
            {
                InfectedCount++;
            }
        }

        public void MoveForward()
        {
            _position = _currentDirection.Move(_position);
        }
    }
}
