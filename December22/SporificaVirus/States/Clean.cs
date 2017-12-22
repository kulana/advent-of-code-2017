using System;

namespace SporificaVirus.States
{
    public class Clean : CellState
    {
        protected override string Title => "clean";

        public override CellState Change() => new Weakened();
    }
}
