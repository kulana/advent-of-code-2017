using System;

namespace SporificaVirus.States
{
    public class Weakened : CellState
    {
        public Weakened() : this(() => { }) { }

        public Weakened(Action action) : base(action)
        {
        }

        protected override string Title => "weakened";

        public override CellState Change(Action action)
        {
            action();
            return new Infected(action);
        }
    }
}
