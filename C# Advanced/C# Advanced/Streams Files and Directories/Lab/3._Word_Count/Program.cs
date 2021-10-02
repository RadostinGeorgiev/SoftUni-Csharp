using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsFile = Path.Combine("data", "words.txt");
            using StreamReader srw = new StreamReader(wordsFile);
            Dictionary<string, int> wordsList = new Dictionary<string, int>();

            string[] words = srw.ReadLine().Split();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                if (!wordsList.ContainsKey(currentWord))
                {
                    wordsList.Add(currentWord, 0);
                }
            }

            string textFile = Path.Combine("data", "input.txt");
            using StreamReader srt = new StreamReader(textFile);
            string input;
            while ((input = srt.ReadLine()) != null)
            {
                words = input.Split(new char[] { ' ', '-', ',', '.', '!', '?' });
                foreach (var word in words)
                {
                    if (wordsList.ContainsKey(word.ToLower()))
                    {
                        wordsList[word.ToLower()]++;
                    }
                }
            }

            string outputFile = Path.Combine("data", "output.txt");
            using StreamWriter sw = new StreamWriter(outputFile);
            foreach (var kVP in wordsList.OrderByDescending(x => x.Value))
            {
                sw.WriteLine($"{kVP.Key} - {kVP.Value}");
            }
        }
    }
}