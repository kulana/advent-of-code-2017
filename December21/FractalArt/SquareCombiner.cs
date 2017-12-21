using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalArt
{
    public class SquareCombiner
    {
        private readonly IList<Square> _squares;
        private readonly int _subSquareDimension;

        public SquareCombiner(IList<Square> squares)
        {
            _squares = squares;
            _subSquareDimension = squares.First().Dimension;
        }

        public Square Join()
        {
            if (_squares.Count == 1)
            {
                return _squares.First();
            }
            int squareSize = _squares.First().Dimension;
            int squareCellCount = squareSize * squareSize;
            int totalCells = _squares.Count * squareCellCount;
            int newDimension = (int)Math.Sqrt(totalCells);
            int squaresPerRow = newDimension / squareSize;
            var newContents = new StringBuilder();
            for (var row = 0; row < newDimension; row++)
            {
                int col = 0;
                while (col < newDimension)
                {
                    int squareIndex = ((row / _subSquareDimension) * squaresPerRow) + (col / _subSquareDimension);
                    newContents.Append(GetCellContentFor(_squares[squareIndex], row % squareSize, col % squareSize));
                    col++;
                    if (col % newDimension == 0)
                    {
                        newContents.Append("/");
                    }
                }
            }
            var result = new Square(newContents.ToString());
            return result;
        }

        private string GetCellContentFor(Square square, int row, int col)
        {
            return square.ValueAt(row, col);
        }
    }
}
