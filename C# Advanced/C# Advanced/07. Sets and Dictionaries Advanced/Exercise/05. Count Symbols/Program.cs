using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbols.ContainsKey(text[i]))
                {
                    symbols.Add(text[i], 0);
                }

                symbols[text[i]]++;
            }

            foreach (var kVP in symbols)
            {
                Console.WriteLine($"{kVP.Key}: {kVP.Value} time/s");
            }
        }
    }
}
