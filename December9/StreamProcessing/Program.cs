using Common;
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
            var fileProcessor = new FileProcessor();
            Context ctx = new Context(0);
            IState state = new None();
            foreach (char c in fileProcessor.ReadFileToEnd(filePath))
            {
                state = state.Transition(c, ctx);
            }
            Console.WriteLine($"Total score = {ctx.TotalScore}");
        }
    }
}
