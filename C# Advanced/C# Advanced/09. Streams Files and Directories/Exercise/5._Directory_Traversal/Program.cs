using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _5._Directory_Traversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> filesList = new Dictionary<string, List<FileInfo>>();
            foreach (var pathFile in files)
            {
                FileInfo infoArgs = new FileInfo(pathFile);
                var fileExtension = infoArgs.Extension;

                if (!filesList.ContainsKey(fileExtension))
                {
                    filesList.Add(fileExtension, new List<FileInfo>());
                }

                filesList[fileExtension].Add(infoArgs);
            }

            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            using StreamWriter sw = new StreamWriter(path);

            foreach (var fileInfo in filesList
                .OrderByDescending(x=>x.Value.Count)
                .ThenBy(x=>x.Key))
            {
                await sw.WriteLineAsync(fileInfo.Key);
                foreach (var info in fileInfo.Value.OrderBy(x=>x.Length))
                {
                    await sw.WriteLineAsync($"--{info.Name} - {(double)info.Length / 1024:F3}kb");
                }
            }
        }
    }
}
