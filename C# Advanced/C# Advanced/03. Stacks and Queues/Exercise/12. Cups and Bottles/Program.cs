using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedLittersOfWater = 0;

            while ((bottles.Count > 0) && (cups.Count > 0))
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek();

                while (currentCup > 0)
                {
                    currentCup -= currentBottle;
                    if (currentCup <= 0)
                    {
                        wastedLittersOfWater -= currentCup;
                        cups.Dequeue();
                    }
                    else
                    {
                        currentBottle = bottles.Pop();
                    }
                }
            }

            Console.WriteLine(bottles.Count > 0
                ? $"Bottles: {string.Join(' ', bottles)}"
                : $"Cups: {string.Join(' ', cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
