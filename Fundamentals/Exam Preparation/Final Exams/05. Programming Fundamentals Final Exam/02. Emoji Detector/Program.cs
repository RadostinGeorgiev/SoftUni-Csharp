using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string cool = @"\d";
            var matches = Regex.Matches(text, cool);
            int coolThreshold = 1;
            foreach (Match d in matches)
            {
                coolThreshold *= int.Parse(d.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");


            string pattern = @"([*]{2}|[:]{2})(?<emojis>[A-Z][a-z]{2,})\1";
            var emojis = Regex.Matches(text, pattern);

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojis)
            {
                int coolness = 0;
                var word = emoji.Groups["emojis"].Value;
                for (var i = 0; i < word.Length; i++)
                {
                    coolness += word[i];
                }

                if (coolness > coolThreshold)
                {
                    Console.WriteLine(emoji.Groups[0].Value);
                }
            }
        }
    }
}
