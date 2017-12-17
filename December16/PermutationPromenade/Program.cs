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
            var memory = new List<string>();

            foreach (var value in input.Split(','))
            {
                moves.Add(Parser.Parse(value));
            }


            // treat programs as a list of numbers, those are easier to replace
            var bytes = Encoding.ASCII.GetBytes("abcdefghijklmnop").ToList();
            var numIterations = 1000000000;
            int i = 1;
            while (i <= numIterations)
            {
                moves.ForEach(move => move.Perform(bytes));
                string result = Encoding.UTF8.GetString(bytes.ToArray());
                Console.WriteLine($"Result for iteration {i} = {result}");
                if (memory.Contains(result))
                {
                    Console.WriteLine($"Same string after {i} iterations");
                    var resultIndex = 1000000000 % (i-1);
                    Console.WriteLine($"Final result = {memory[resultIndex-1]}");
                    break;
                }
                else {
                    memory.Add(result);
                    i++;
                }
            }
        }
    }
}
