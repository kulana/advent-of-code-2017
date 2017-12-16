using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PermutationPromenade
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var fileProcessor = new FileProcessor();
            string input = fileProcessor.ReadFileToEnd(filePath);
            var moves = new List<DanceMove>();

            // treat programs as a list of numbers, those are easier to replace
            var bytes = Encoding.ASCII.GetBytes("abcdefghijklmnop").ToList();
            foreach (var value in input.Split(','))
            {
                var move = Parser.Parse(value);
                move.Perform(bytes);
            }
 
            Console.WriteLine($"Final result = {Encoding.UTF8.GetString(bytes.ToArray())}");
        }
    }
}
