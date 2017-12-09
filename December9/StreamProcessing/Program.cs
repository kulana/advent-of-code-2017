using StreamProcessing.State;
using System;
using System.IO;

namespace StreamProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            Context ctx = new Context(0);
            IState state = new None();
            foreach (char c in GetFileContents(filePath))
            {
                state = state.Transition(c, ctx);
            }
            Console.WriteLine($"Total score = {ctx.TotalScore}");
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
