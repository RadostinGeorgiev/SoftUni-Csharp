using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numbersAverage = numbers.Average();
            var output = numbers.Where(x => x > numbersAverage).OrderByDescending(x => x).Take(5).ToList();
            if (output.Count > 0)
            {
                Console.WriteLine(string.Join(' ', output));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
