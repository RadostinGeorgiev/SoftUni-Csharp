using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (wordCounter.ContainsKey(item))
                {
                    wordCounter[item]++;
                }
                else
                {
                    wordCounter.Add(item, 1);
                }
            }

            var filteredDictionary = wordCounter.Where(x => x.Value % 2 == 1);
            foreach (var item in filteredDictionary)
            {
                Console.Write(item.Key + ' ');
            }
        }
    }
}
