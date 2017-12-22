using SporificaVirus.States;
using System;
using System.Collections.Generic;

namespace SporificaVirus
{
    public class Puzzle2DirectionStrategy : IDirectionStrategy
    {
        //If it is clean, it turns left.
        //If it is weakened, it does not turn, and will continue moving in the same direction.
        //If it is infected, it turns right.
        //If it is flagged, it reverses direction, and will go back the way it came.
        private static IDictionary<CellState, Func<Direction, Direction>> _mapping = new Dictionary<CellState, Func<Direction, Direction>>()
        {
            { new Clean(), (d) => d.TurnLeft() },
            { new Weakened(), (d) => d },
            { new Infected(), (d) => d.TurnRight() },
            { new Flagged(), (d) => d.Reverse }
        };

        public Direction NewDirection(GridCell cell, Direction currentDirection)
        {
            var state = cell.State;
            var newDirectionFunc = _mapping[cell.State];
            return newDirectionFunc(currentDirection);
        }
    }
}
