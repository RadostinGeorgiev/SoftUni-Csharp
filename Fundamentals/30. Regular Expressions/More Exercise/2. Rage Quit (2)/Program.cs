using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit__2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            string[] words = Regex.Split(text, @"(\d+)", RegexOptions.Compiled);

            for (int i = 0; i < words.Length-1; i += 2)
            {
                string word = words[i].ToUpper();
                int repeat = int.Parse(words[i + 1]);
                for (int j = 1; j <= repeat; j++)
                {
                    output.Append(word);
                }
            }

            int uniqueSymbols = output.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(output);
        }
    }
}
