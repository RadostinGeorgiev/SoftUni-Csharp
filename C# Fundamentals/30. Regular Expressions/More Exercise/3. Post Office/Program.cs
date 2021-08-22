using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string firstLetterPattern = @"([#$%&*])(?<firstLetters>[A-Z]+)\1";
            string lengthsPattern = @"(?=.{1,20})(?<firstLetter>\d{2,3}):(?<length>\d{2})+";
            string wordsPattern = @"\b([A-Z]\S+)\b";

            var firstMatches = Regex.Matches(parts[0], firstLetterPattern);
            var secondMatches = Regex.Matches(parts[1], lengthsPattern);
            var thirdMatches = Regex.Matches(parts[2], wordsPattern);

            char[] wordFirstLetters = null;
            foreach (Match firstMatch in firstMatches)
            {
                wordFirstLetters = firstMatch.Groups["firstLetters"].Value.ToCharArray();
            }

            Dictionary<char, int> wordsLength = new Dictionary<char, int>();
            foreach (Match secondMatch in secondMatches)
            {
                char firstLetter = (char)int.Parse(secondMatch.Groups["firstLetter"].Value);
                int length = int.Parse(secondMatch.Groups["length"].Value) + 1;

                if (wordFirstLetters.Contains(firstLetter) && (!wordsLength.ContainsKey(firstLetter)))
                    wordsLength.Add(firstLetter, length);
            }

            Dictionary<char, string> words = new Dictionary<char, string>();
            foreach (Match thirdMatch in thirdMatches)
            {
                string word = thirdMatch.Value;
                if ((wordFirstLetters.Contains(word[0])) &&
                    (word.Length == wordsLength[word[0]]))
                {
                    words.Add(word[0], word);
                }
            }

            foreach (var wordFirstLetter in wordFirstLetters)
            {
                Console.WriteLine(words[wordFirstLetter]);
            }
        }
    }
}
