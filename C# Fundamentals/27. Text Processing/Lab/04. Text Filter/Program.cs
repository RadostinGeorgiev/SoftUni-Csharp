﻿using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in words)
            {
                string newWord = new string('*', word.Length);
                while (text.Contains(word))
                {
                    text = text.Replace(word, newWord);
                }
            }

            Console.WriteLine(text);
        }
    }
}
