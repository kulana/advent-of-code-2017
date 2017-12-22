using System;

namespace SporificaVirus.States
{
    public class Flagged : CellState
    {
        protected override string Title => "flagged";

        public override CellState Change() => new Clean();
    }

}
