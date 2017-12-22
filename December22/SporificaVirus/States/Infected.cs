using System;

namespace SporificaVirus.States
{
    public class Infected : CellState
    {
        protected override string Title => "infected";

        public override CellState Change() => new Flagged();

        public override bool IsInfected => true;
    }
}
