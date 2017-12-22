using System;

namespace SporificaVirus.States
{
    public abstract class CellState
    {
        protected abstract string Title { get; } 

        private readonly Action _action;

        public CellState(Action action)
        {
            _action = action;
        }

        public abstract CellState Change(Action action);

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
    }
}
