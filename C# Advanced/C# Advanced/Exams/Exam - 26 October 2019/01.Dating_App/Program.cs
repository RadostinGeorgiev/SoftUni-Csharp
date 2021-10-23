using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                if (males.Peek() <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (females.Peek() <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (males.Peek() % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                if (females.Peek() % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if (males.Peek() == females.Peek())
                {
                    males.Pop();
                    matches++;
                }
                else
                {
                    males.Push(males.Pop() - 2);
                }
                females.Dequeue();
            }

            Console.WriteLine($"Matches: {matches}");
            Console.WriteLine(males.Count == 0 
                ? "Males left: none" 
                : $"Males left: {string.Join(", ", males)}");
            Console.WriteLine(females.Count == 0 
                ? "Females left: none" 
                : $"Females left: {string.Join(", ", females)}");
        }
    }
}