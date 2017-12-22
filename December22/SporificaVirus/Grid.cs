using System.Collections.Generic;

namespace SporificaVirus
{
    public class Grid
    {
        private IDictionary<string, GridCell> _grid = new Dictionary<string, GridCell>();

        public Grid()
        {
        }

        public void Add(GridCell cell)
        {
            _grid[CellKey(cell)] = cell;
        }

        private string CellKey(GridCell cell) => $"{cell.Position.X},{cell.Position.Y}";
    }
}
