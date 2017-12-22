using System;

namespace SporificaVirus.States
{
    public class Clean : CellState
    {
        public Clean() : this(() => { }) { }

        public Clean(Action action) : base(action)
        {
        }

        protected override string Title => "clean";

        public override CellState Change(Action action) => new Weakened(action);
    }
}
