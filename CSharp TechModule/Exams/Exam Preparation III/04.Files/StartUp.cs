using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, long> data = new Dictionary<string, long>();
            List<string> filePaths = new List<string>();
            int numberOfFilePaths = int.Parse(Console.ReadLine());
            bool isDataFound = false;

            for (int i = 0; i < numberOfFilePaths; i++)
            {
                string inputFilePaths = Console.ReadLine();
                filePaths.Add(inputFilePaths);
            }

            string query = Console.ReadLine();
            var queryArgs = query
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < filePaths.Count; i++)
            {
                var pathArgs = filePaths[i]
                    .Split(new char[] { '\\' },StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var fileWithSize = pathArgs[pathArgs.Count - 1]
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string file = fileWithSize[0];
                long fileSize = long.Parse(fileWithSize[fileWithSize.Count - 1]);
                string rootDir = pathArgs[0];
                var fileNameSplitted = file.Split('.').ToList();
                string fileExtention = fileNameSplitted[fileNameSplitted.Count - 1];

                if (fileExtention == queryArgs[0] && rootDir == queryArgs[2])
                {
                    isDataFound = true;

                    if (!data.ContainsKey(file))
                    {
                        data.Add(file, fileSize);
                    }
                    else
                    {
                        data[file] = fileSize;
                    }
                }
            }
            if (isDataFound)
            {
                foreach (var d in data.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{d.Key} - {d.Value} KB");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
