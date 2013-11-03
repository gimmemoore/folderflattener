using System;
using CommandLine;

namespace FolderFlattener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            var result = Parser.Default.ParseArguments(args, options);
            if (result)
            {
                var flat = new Flattener(options);
                flat.Run();
            }
            else
                Console.WriteLine("Error parsing command ligne arguments");

            Console.WriteLine("Operation completed");
        }      
    }
}
