using System;
using System.IO;

namespace HexEd
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            var moves = GetFileContents(filePath).Split(',');
            var position = new Position(0, 0);
            foreach (var move in moves)
            {
                position.Move(Direction.GetDirection(move));
            }
            Console.WriteLine(position.DetermineMinimumStepsFrom(new Position(0, 0)));
        }

        static string GetFileContents(string path)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }
    }
}
