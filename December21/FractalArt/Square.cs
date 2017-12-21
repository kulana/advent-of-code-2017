using System.Collections.Generic;

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
    }
}
