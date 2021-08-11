using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(@|#)(?<wordFirst>[A-Za-z]{3,})\1\1(?<wordSecond>[A-Za-z]{3,})\1";
            List<string> mirrors = new List<string>();

            if (Regex.IsMatch(text, pattern))
            {
                var matches = Regex.Matches(text, pattern);

                foreach (Match match in matches)
                {
                    string wordFirst = match.Groups["wordFirst"].Value;
                    string wordSecond = match.Groups["wordSecond"].Value;
                    string mirrorWord = new String(wordSecond.ToCharArray().Reverse().ToArray());
                    if (wordFirst == mirrorWord)
                    {
                        mirrors.Add(wordFirst + " <=> " + wordSecond);
                    }
                }

                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrors.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrors));
            }
        }
    }
}
