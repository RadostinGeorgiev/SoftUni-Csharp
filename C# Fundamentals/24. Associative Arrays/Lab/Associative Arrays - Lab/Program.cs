
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> sortedNumbers = new SortedDictionary<int, int>();
            foreach (var item in numbers)
            {
                if (sortedNumbers.ContainsKey(item))
                {
                    sortedNumbers[item]++;
                }
                else
                {
                    sortedNumbers.Add(item, 1);
                }
            }

            foreach (var keyValuePair in sortedNumbers)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
