using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskDefragmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = GetLengthSequence("flqrgnkx");
        }

        static IList<byte> GetLengthSequence(string value)
        {
            var additionalValues = new byte[] { 17, 31, 73, 47, 23 };
            var bytes = Encoding.ASCII.GetBytes(value).ToList();
            bytes.AddRange(additionalValues);
            return bytes;
        }
    }
}
