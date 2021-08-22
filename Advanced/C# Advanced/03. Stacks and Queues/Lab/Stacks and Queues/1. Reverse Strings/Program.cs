using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<char> reversedText = new Stack<char>();

            for (var i = 0; i < text.Length; i++)
            {
                reversedText.Push(text[i]);
            }

            while (reversedText.Count > 0)
            {
                Console.Write(reversedText.Pop());
            }
        }
    }
}
