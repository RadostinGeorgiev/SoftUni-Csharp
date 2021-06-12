using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(CountVowel(input));
        }

        static int CountVowel(string input)
        {
            int vowelsCounter = 0;
            input = input.ToLower();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                switch (currentChar)
                {
                    case 'a':
                    case 'e':
                    case 'o':
                    case 'u':
                    case 'i':
                        vowelsCounter++;
                        break;
                }
            }

            return vowelsCounter;
        }
    }
}
