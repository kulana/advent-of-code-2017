using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalArt
{
    public class Square
    {
        private readonly string _originalContents;
        private readonly IList<string> _contents;

        public Square()
        {
        }

        public Square(string contents)
        {
            _originalContents = contents;
            _contents = new List<string>();
            foreach (var row in _originalContents.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                _contents.Add(row);
            }
        }

        // row and column are 0-based
        public string ValueAt(int row, int column)
        {
            var rowContents = _contents[row];
            return rowContents[column].ToString();
        }

        public int Dimension => _contents.Count;

        public int CellCount => Dimension * Dimension;

        public int PixelsOn
        {
            get
            {
                int count = 0;
                foreach (var row in _contents)
                {
                    count += row.Where(c => c == '#').Count();
                }
                return count;
            }
        }

        public IList<Square> Divide(int subSquareDimension)
        {
            int subSquaresNeeded = (int)Math.Pow(this.Dimension / subSquareDimension, 2);
            int subSquareCellCount = this.CellCount / subSquaresNeeded;
            int squaresPerRow = this.Dimension / subSquareDimension;
            var subSquares = new List<string>(subSquaresNeeded);
            Enumerable.Range(1, subSquaresNeeded).ToList().ForEach(i => subSquares.Add(string.Empty));

            for (int row = 0; row < this.Dimension; row++)
            {
                int col = 0;
                while (col < this.Dimension)
                {
                    int subSquareIndex = ((row / subSquareDimension) * squaresPerRow) + (col / subSquareDimension);
                    var value = this.ValueAt(row, col);
                    // put value in correct subsquare
                    subSquares[subSquareIndex] += value;
                    col++;
                    if (col % subSquareDimension == 0)
                    {
                        subSquares[subSquareIndex] += "/";
                    }
                }
            }
            return CreateSubSquares(subSquares);
        }

        private IList<Square> CreateSubSquares(IList<string> subSquares)
        {
            return subSquares.Select(str => new Square(str)).ToList();
        }
    }
}
