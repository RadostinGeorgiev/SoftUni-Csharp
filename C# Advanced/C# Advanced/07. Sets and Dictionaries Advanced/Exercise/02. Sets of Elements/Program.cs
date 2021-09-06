using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> second = new HashSet<int>();
            for (int i = 0; i < input[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            first.IntersectWith(second);
            Console.WriteLine(string.Join(' ', first));
        }
    }
}
