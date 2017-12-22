using SporificaVirus.States;
using System;

namespace SporificaVirus
{
    public class GridCell
    {
        public CellState State { get; set; }
        public Position Position { get; private set; }

        public GridCell(Position position, CellState state)
        {
            Position = position;
            State = state;
        }

        public GridCell(Position position) : this(position, new Clean()) { }
    }
}
