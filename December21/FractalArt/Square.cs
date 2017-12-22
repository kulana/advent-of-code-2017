using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalArt
{
    public class Square
    {
        private readonly string _originalContents;
        private readonly IList<string> _contents;

        private IList<string> _variations;   // contains the rotated and flipped variations;

        public Square(): this(string.Empty)
        { }

        public Square(string contents)
        {
            _originalContents = contents.TrimEnd('/');
            _contents = new List<string>();
            foreach (var row in _originalContents.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                _contents.Add(row);
            }
            DetermineVariations();
        }

        private void DetermineVariations()
        {
            _variations = new List<string>();
            string input = _originalContents;
            for (int i = 0; i < 4; i++)
            {
                // add original
                _variations.Add(input);
                // add flipped
                _variations.Add(Flip(input));
                // rotate 90%
                input = Rotate(input);
            }           
        }

        private string Flip(string input)
        {
            var workList = new List<string>(_contents);
            int halfWayRow = this.Dimension / 2;
            for (int rowToFlip = 0; rowToFlip < halfWayRow; rowToFlip++)
            {
                int rowToFlipWith = this.Dimension - 1 - rowToFlip;
                string rowContents = workList[rowToFlip];
                string temp = workList[rowToFlipWith];
                workList[rowToFlip] = temp;
                workList[rowToFlipWith] = rowContents;
            }
            return Stringify(workList);
        }

        private string Stringify(IList<string> list)
        {
            string result = string.Empty;
            foreach (var row in list)
            {
                result += row + "/";
            }
            return result.TrimEnd('/');
        }

        private string Rotate(string input)
        {
            var rotated = string.Empty;
            int startPos = this.Dimension;
            var cleaned = input.Replace("/", "");
            int charsAdded = 0;
            for (int i = 0; i < cleaned.Length; i++)
            {
                int index = (startPos + i) % cleaned.Length;
                rotated += cleaned[index];
                charsAdded++;
                if (charsAdded % this.Dimension == 0)
                {
                    rotated += '/';
                }
            }
            return rotated;
        }


        public bool Matches(string rule)
        {
            return (_variations.Contains(rule));
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
