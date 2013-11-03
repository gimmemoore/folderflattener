using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderFlattener
{
    public class Flattener
    {
        private readonly Options _options;

        public Flattener(Options options)
        {
            _options = options;            
        }

        public bool Verbose {get { return _options.Verbose; }}

        public void Run()
        {
            if (_options.Root != null && _options.Root.Any())
            {
                foreach (var root in _options.Root)
                    ProcessRootFolder(root);
            }
            else
                WriteLine("You must specify at least one Root directory [r]");
        }

        private void ProcessRootFolder(string root)
        {
            WriteLine("Getting all files in '{0}'...", root);

            var files = GetAllFiles(root);

            WriteLine("Creating the destination folder '{0}'...", _options.Destination);

            var destinationFolder = GetDestinationFolder(root, _options.Destination);

            CopyFilesToDestination(files, destinationFolder);
        }

        private void CopyFilesToDestination(IEnumerable<string> files, string destinationFolder)
        {
            foreach (var file in files)
            {
                if (string.IsNullOrEmpty(file))
                    continue;

                // ReSharper disable AssignNullToNotNullAttribute
                var to = Path.Combine(destinationFolder, Path.GetFileName(file));
                // ReSharper restore AssignNullToNotNullAttribute

                WriteLine("Creating a copy of '{0}' to '{1}'", file, to);

                // TODO : Managed Exception and Exception resume on exit
                try
                {
                    File.Copy(file, to, true);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press a key to continue process or q to stop");

                    var value = Console.ReadKey();
                    if (value.Key == ConsoleKey.Q)
                        Environment.Exit(1);

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private string GetDestinationFolder(string root, string destination)
        {
            if (!Path.IsPathRooted(destination))
            {
                WriteLine("Path '{0}' not rooted, adding it to the root folder '{1}'", destination, root);

                root = Path.Combine(root, destination);

                if (!Directory.Exists(root))
                {
                    WriteLine("Creating new root at '{0}'", root);
                    Directory.CreateDirectory(root);
                }

                WriteLine("New root is now '{0}'", root);
            }

            return root;
        }

        private static IEnumerable<string> GetAllFiles(string path)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }

        private void WriteLine(string format, params object[] arguments)
        {
            if (Verbose)
                Console.WriteLine(format, arguments);            
        }
    }
}