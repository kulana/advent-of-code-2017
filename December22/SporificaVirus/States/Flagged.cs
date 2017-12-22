using System;

namespace SporificaVirus.States
{
    public class Flagged : CellState
    {
        public Flagged() : this(() => { }) { }

        public Flagged(Action action) : base(action)
        {
        }

        protected override string Title => "flagged";

        public override CellState Change(Action action) => new Clean(action);
    }

}
