using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int downLimit = numbers[0];
            int upLimit = numbers[1];

            string filter = Console.ReadLine();

            Predicate<int> query = x => filter == "odd" ?
                x % 2 != 0 :
                x % 2 == 0;

            List<int> result = new List<int>();
            for (int i = downLimit; i <= upLimit; i++)
            {
                if (query(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}