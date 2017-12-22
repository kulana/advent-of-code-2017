using System;

namespace SporificaVirus.States
{
    public class Weakened : CellState
    {
        protected override string Title => "weakened";

        public override CellState Change() => new Infected();
    }
}
