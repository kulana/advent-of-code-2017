using System.Collections.Generic;
using System.Linq;

namespace FractalArt
{
    public class Square
    {
        private readonly IList<string> _contents;

        public Square(string contents)
        {
            _contents = new List<string>();
            foreach (var row in contents.Split('/'))
            {
                _contents.Add(row);
            }
        }

        public int Size => _contents.Count;

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
    }
}
