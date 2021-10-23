using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> words  = new Dictionary<string, List<char>>
            {
                { "pear", "pear".ToCharArray().ToList()},
                { "flour","flour".ToCharArray().ToList()},
                { "pork", "pork".ToCharArray().ToList()},
                { "olive", "olive".ToCharArray().ToList()}
            };

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());

            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonants = consonants.Pop();

                foreach (var word in words.Values)
                {
                    if (word.Contains(currentVowel))
                    {
                        word.RemoveAll(x => x == currentVowel);
                    }

                    if (word.Contains(currentConsonants))
                    {
                        word.RemoveAll(x => x == currentConsonants);
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            Console.WriteLine($"Words found: {words.Count(x=>x.Value.Count == 0)}");
            foreach (var kVP in words.Where(x=>x.Value.Count == 0))
            {
                Console.WriteLine(kVP.Key); 
            }
        }
    }
}