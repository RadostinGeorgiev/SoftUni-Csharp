using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<char> text = Console.ReadLine()
                .ToCharArray().ToList();
            StringBuilder message = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                int charPosition = SumDigits(numbers[i]) % text.Count;
                message.Append(text[charPosition]);
                text.RemoveAt(charPosition);
            }

            Console.WriteLine(message);
        }

        static int SumDigits(int input)
        {
            int sum = 0;
            while (input != 0)
            {
                sum += input % 10;
                input /= 10;
            }

            return sum;
        }
    }
}
