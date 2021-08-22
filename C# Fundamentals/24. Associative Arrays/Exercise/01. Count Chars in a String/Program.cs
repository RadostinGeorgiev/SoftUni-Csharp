using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            Dictionary<char, int> symbols = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (c != ' ')
                {
                    if (symbols.ContainsKey(c))
                    {
                        symbols[c]++;
                    }
                    else
                    {
                        symbols.Add(c, 1);
                    }
                }
            }

            foreach (var keyValuePair in symbols)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
