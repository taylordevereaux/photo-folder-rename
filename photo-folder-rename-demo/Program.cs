using System;
using System.IO;

namespace photo_folder_rename_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = ".\\test-data";

            if (Directory.Exists(directory)) 
            {
                Directory.Delete(directory, true);
                Directory.CreateDirectory(directory);
            }

            DateTime date = DateTime.Now;
            TimeSpan span = new TimeSpan(date.Ticks);
            Random random = new Random((int)span.TotalSeconds);

            Console.WriteLine("--\t Generating Test Folders\t--");

            for (int i = 0; i < 36; ++i)
            {

                string newDirectory = $"{date.Month}-{date.Day}-{date.Year}";// date.ToString("MM-dd-yyyy");
                Directory.CreateDirectory(Path.Combine(directory, newDirectory));

                date = date.AddDays(-random.Next(1, 6));

                Console.WriteLine(newDirectory);
            }
        }
    }
}
