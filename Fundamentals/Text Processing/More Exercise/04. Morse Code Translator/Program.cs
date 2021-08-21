using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseAlphabet = new Dictionary<string, char>()
            {
                { ".-", 'A'},
                { "-...", 'B'},
                { "-.-.", 'C'},
                { "-..", 'D'},
                { ".", 'E'},
                { "..-.", 'F'},
                { "--.", 'G'},
                { "....", 'H'},
                { "..", 'I'},
                { ".---", 'J'},
                { "-.-", 'K'},
                { ".-..", 'L'},
                { "--", 'M'},
                { "-.", 'N'},
                { "---", 'O'},
                { ".--.", 'P'},
                { "--.-", 'Q'},
                { ".-.", 'R'},
                { "...", 'S'},
                { "-", 'T'},
                { "..-", 'U'},
                { "...-", 'V'},
                { ".--", 'W'},
                { "-..-", 'X'},
                { "-.--", 'Y'},
                { "--..", 'Z'}
            };

            string[] words = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                string[] letters = word.Split();
                foreach (var letter in letters)
                {
                    if (morseAlphabet.ContainsKey(letter))
                    {
                        sb.Append(morseAlphabet[letter]);
                    }
                }

                sb.Append(' ');
            }

            Console.WriteLine(sb);
        }
    }
}
