using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace photo_folder_rename
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args.Length > 0 ? args[0] : ".\\";
            string searchPattern = args.Length > 1 ? args[1] :  "*-*-*";
            string originalDateFormat = args.Length > 2 ? args[2] :  "MM-dd-yyyy";
            string newDateFormat = args.Length > 3 ? args[3] :  "yyyy-MM-dd";

            var directories = ParseDirectories(path, searchPattern, originalDateFormat, newDateFormat)
                .OrderByDescending(x => x.NewName);

            
            Console.WriteLine("----------\tWelcome to the Directory Renamer\t---------");
            Console.WriteLine("");
            Console.WriteLine($"Directory: {path}");
            Console.WriteLine($"Search Pattern: {searchPattern}");
            Console.WriteLine($"Original Date Format: {originalDateFormat}");
            Console.WriteLine($"New Date Format: {newDateFormat}");
            Console.WriteLine("");

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
                    DirectoryInfo info = new DirectoryInfo(Path.Combine(path, directory.OriginalName));

                    info.MoveTo(Path.Combine(path, directory.NewName));
                }

                Console.WriteLine("Rename successfull!");
                Console.ReadKey();
            }
        }

        private static IEnumerable<(string OriginalName, string NewName)> ParseDirectories(
            string path, 
            string searchPattern,
            string originalDateFormat,
            string newDateFormat
        )
        {

            CultureInfo provider = CultureInfo.InvariantCulture;

            foreach (var directory in Directory.GetDirectories(path, searchPattern))
            {
                DirectoryInfo info = new DirectoryInfo(directory);

                var date = DateTime.ParseExact(info.Name, originalDateFormat, provider);

                yield return (info.Name, date.ToString(newDateFormat));
            }
        }
    }
}
