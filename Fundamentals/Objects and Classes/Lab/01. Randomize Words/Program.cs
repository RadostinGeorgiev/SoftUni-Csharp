using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();


            Random rnd = new Random();
            for (int i = 0; i < words.Count; i++)
            {
                int randomNumber = rnd.Next(0, words.Count);
               
                string currentWord = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
