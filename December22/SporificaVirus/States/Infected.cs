using System;

namespace SporificaVirus.States
{
    public class Infected : CellState
    {
        public Infected() : this(() => { }) { }

        public Infected(Action action) : base(action)
        {
        }

        protected override string Title => "infected";

        public override CellState Change(Action action) => new Flagged(action);
    }
}
