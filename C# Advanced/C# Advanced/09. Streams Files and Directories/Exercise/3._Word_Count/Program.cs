using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3._Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordsList = new Dictionary<string, int>();

            var path = Path.Combine("data", "words.txt");
            string[] words = await File.ReadAllLinesAsync(path);

            foreach (var word in words)
            {
                if (!wordsList.ContainsKey(word))
                {
                    wordsList.Add(word, 0);
                }
            }

            path = Path.Combine("data", "text.txt");
            string[] lines = await File.ReadAllLinesAsync(path);

            foreach (var line in lines)
            {
                words = line.Split(new char[] { ' ', '-', ',', '.', '!', '?' });
                foreach (var word in words)
                {
                    if (wordsList.ContainsKey(word.ToLower()))
                    {
                        wordsList[word.ToLower()]++;
                    }
                }
            }

            path = Path.Combine("data", "actualResult.txt");
            using (File.Create(path));
            foreach (var kVP in wordsList)
            {
                await File.AppendAllTextAsync(path, $"{kVP.Key} - {kVP.Value}{Environment.NewLine}");
            }

            string expectedFilePath = Path.Combine("data", "expectedResult.txt");
            var expectedFile = await File.ReadAllLinesAsync(expectedFilePath);
            int lineCounter = 0;

            foreach (var kVP in wordsList.OrderByDescending(x => x.Value))
            {
                if (!expectedFile[lineCounter].SequenceEqual($"{kVP.Key} - {kVP.Value}"))
                {
                    Console.WriteLine("The results are different");
                    return;
                }
                
                lineCounter++;
            }
            Console.WriteLine("The results are the same");
        }
    }
}