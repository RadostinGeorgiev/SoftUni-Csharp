using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[\s,.!?](?<emoji>:(?<word>[a-z]{4,}):)[\s,.!?]";
            string message = Console.ReadLine();

            int[] code = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string codeWord = String.Empty;

            foreach (var i in code)
            {
                codeWord += (char)i;
            }

            bool isFound = false;
            int power = 0;

            if (Regex.IsMatch(message, pattern))
            {
                var matches = Regex.Matches(message, pattern);

                foreach (Match emoji in matches)
                {
                    string word = emoji.Groups["word"].Value;
                    if (word == codeWord)
                    {
                        isFound = true;
                    }

                    for (var i = 0; i < word.Length; i++)
                    {
                        power += (int)word[i];
                    }
                }

                Console.WriteLine($"Emojis found: {string.Join(", ", matches.Select(x => x.Groups["emoji"].Value))}");

                if (isFound)
                {
                    power *= 2;
                }
            }

            Console.WriteLine($"Total Emoji Power: {power}");
        }
    }
}
