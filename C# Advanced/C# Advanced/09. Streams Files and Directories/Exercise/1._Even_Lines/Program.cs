using System;
using System.IO;

namespace _1._Even_Lines
{
    static class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "text.txt");

            using StreamReader sr = new StreamReader(path);
            int lineCounter = 0;

            string input;
            while ((input = sr.ReadLine()) != null)
            {
                if (lineCounter % 2 == 0)
                {
                    Console.WriteLine(input.ReplaceSymbols().ReverseWords());
                }

                lineCounter++;
            }
        }
        
        private static string ReplaceSymbols(this string input)
        {
            char[] replacementSet = new char[] { '-', ',', '.', '!', '?' };
            foreach (var c in replacementSet)
            {
                input = input.Replace(c, '@');
            }

            return input;
        }
        private static string ReverseWords(this string input)
        {
            string[] words = input.Split();
            Array.Reverse(words);

            return string.Join(' ', words);
        }

    }
}
