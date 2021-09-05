using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            
            foreach (var value in input)
            {
                if (numbers.ContainsKey(value))
                {
                    numbers[value]++;
                }
                else
                {
                    numbers.Add(value, 1);
                }
            }

            foreach (var kVP in numbers)
            {
                Console.WriteLine($"{kVP.Key} - {kVP.Value} times");
            }
        }
    }
}
