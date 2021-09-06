using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                input.ForEach(x=>elements.Add(x));
            }

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}