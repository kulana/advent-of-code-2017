using SporificaVirus.States;
using System;
using System.Collections.Generic;

namespace SporificaVirus
{
    public class Puzzle1DirectionStrategy : IDirectionStrategy
    {
        // If the current node is infected, it turns to its right. Otherwise, it turns to its left. 
        // (Turning is done in-place; the current node does not change.)
        public Direction NewDirection(GridCell cell, Direction currentDirection)
        {
            var state = cell.State;
            if (cell.State.Equals(new Infected()))
            {
                return currentDirection.TurnRight();
            }
            return currentDirection.TurnLeft();
        }
    }
}
