using SporificaVirus.States;
using System;

namespace SporificaVirus
{
    public class GridCell
    {
        public CellState State { get; set; }
        public Position Position { get; private set; }

        public GridCell(Position position) : this(position, () => { })
        { }

        public GridCell(Position position, Action infectedAction)
        {
            Position = position;
            State = new Clean(infectedAction);
        }
    }
}
