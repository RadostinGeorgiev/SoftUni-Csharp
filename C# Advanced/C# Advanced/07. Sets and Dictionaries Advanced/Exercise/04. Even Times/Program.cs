using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(input))
                {
                    numbers.Add(input, 0);
                }

                numbers[input]++;
            }

            Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
        }
    }
}
