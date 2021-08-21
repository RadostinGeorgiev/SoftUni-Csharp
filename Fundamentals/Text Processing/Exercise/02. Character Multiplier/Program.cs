using System;
using System.Diagnostics.CodeAnalysis;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string wordOne = input[0];
            string wordTwo = input[1];
            int sum = 0;

            for (int i = 0; i < Math.Max(wordOne.Length, wordTwo.Length); i++)
            {
                int multiplierOne = 1;
                int multiplierTwo = 1;

                if (i < wordOne.Length)
                {
                    multiplierOne = wordOne[i];
                }

                if (i < wordTwo.Length)
                {
                    multiplierTwo = wordTwo[i];
                }

                sum += multiplierOne * multiplierTwo;
            }

            Console.WriteLine(sum);
        }
    }
}
