using System;
using System.Collections.Generic;

namespace SporificaVirus
{
    public class Grid
    {
        private int _maxX, _maxY = 0;

        private IDictionary<string, GridCell> _grid = new Dictionary<string, GridCell>();

        public Grid()
        {
        }

        public void Add(GridCell cell)
        {
            _grid[CellKey(cell.Position)] = cell;
            // update max X,Y values so we can determine center later 
            _maxX = Math.Max(cell.Position.X, _maxX);
            _maxY = Math.Max(cell.Position.Y, _maxY);
        }

        private string CellKey(Position position) => $"{position.X},{position.Y}";

        public Position Center()
        {
            return new Position((_maxX / 2), (_maxY / 2));
        }

        public GridCell GetCell(Position position, Action infectedAction)
        {
            var key = CellKey(position);
            if (!_grid.ContainsKey(key))
            {
                // create new uninfected cell on position
                var newCell = new GridCell(position, infectedAction);
                Add(newCell);
                return newCell;
            }
            return _grid[key];
        }
    }
}
