using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first  = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray());
            Stack<int> second = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray());
            int claimedItems = 0;

            while (first.Count > 0 && second.Count > 0)
            {
                int sum = first.Peek() + second.Peek();

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }

            Console.WriteLine(first.Count == 0 
                ? "First lootbox is empty" 
                : "Second lootbox is empty");
            Console.WriteLine(claimedItems >= 100
                ? $"Your loot was epic! Value: {claimedItems}"
                : $"Your loot was poor... Value: {claimedItems}");
        }
    }
}