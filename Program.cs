using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace photo_folder_rename
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args.Length > 0 ? args[0] : "./test/rename";
            string searchPattern = args.Length > 1 ? args[1] :  "*-*-*";

            var directories = ParseDirectories(path, searchPattern)
                .OrderByDescending(x => x.NewName);

            
            Console.WriteLine("----------\tWelcome to the Directory Renamer\t---------");

            Console.WriteLine($"Directory: {path}");

            foreach (var directory in directories)
            {
                Console.WriteLine($"{directory.OriginalName} -> {directory.NewName}");
            }

            Console.WriteLine("");
            Console.WriteLine("Rename directories? (Y/N)");

            var input = Console.ReadLine();

            if (input == "Y" || input == "y")
            {
                foreach (var directory in directories)
                {
                    DirectoryInfo info = new DirectoryInfo(directory.OriginalName);

                    info.MoveTo(directory.NewName);
                }
                
                directories = ParseDirectories(path, searchPattern)
                    .OrderByDescending(x => x.OriginalName);

                Console.WriteLine("Rename successful!");

                foreach (var directory in directories)
                {
                    Console.WriteLine(directory.OriginalName);
                }

                Console.ReadKey();
            }
        }

        private static IEnumerable<(string OriginalName, string NewName)> ParseDirectories(string path, string searchPattern)
        {
            foreach (var directory in Directory.GetDirectories(path, searchPattern))
            {
                DirectoryInfo info = new DirectoryInfo(directory);

                string[] parts = info.Name.Split('-');

                string newFormat = $"{parts[2]}-{parts[0]}-{parts[1]}";

                yield return (info.Name, newFormat);
            }
        }
    }
}
