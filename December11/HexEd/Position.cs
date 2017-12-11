using System;

namespace HexEd
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Direction direction)
        {
            X = X + direction.X;
            Y = Y + direction.Y;
        }

        /// <summary>
        /// Imagine strting at position 0,0
        /// First go diagonally to get above or below the Y coordinate.
        /// Then go vertical, every step in/decreases Y with 2.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int DetermineMinimumStepsFrom(Position fromPosition)
        {
            int resultX = Math.Abs(this.X - fromPosition.X);
            int resultY = Math.Abs(this.Y - fromPosition.Y);
            int diagonalSteps = Math.Min(resultX, resultY);
            int verticalSteps = Math.Max(resultX, resultY);
            return Math.Abs(verticalSteps - diagonalSteps) / 2 + diagonalSteps;
        }

        public override string ToString()
        {
            return $"X = {X}, Y={Y}";
        }
    }
}
