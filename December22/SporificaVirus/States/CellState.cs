using System;

namespace SporificaVirus.States
{
    public abstract class CellState
    {
        protected abstract string Title { get; } 

        public abstract CellState Change();

        public override bool Equals(object obj)
        {
            return Equals(obj as CellState);
        }

        public bool Equals(CellState obj)
        {
            return Title.Equals(obj.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }

        public virtual bool IsInfected => false;
    }
}
