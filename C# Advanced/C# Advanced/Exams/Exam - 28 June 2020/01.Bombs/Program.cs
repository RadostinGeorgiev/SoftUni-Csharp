using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> bombs = new Dictionary<int, string>()
            {
                {40, "Datura Bombs" }, 
                {60, "Cherry Bombs" }, 
                {120, "Smoke Decoy Bombs" }
            };

            SortedDictionary<string, int> createdBombs = new SortedDictionary<string, int>()
            {
                {"Datura Bombs", 0 }, 
                {"Cherry Bombs", 0 }, 
                {"Smoke Decoy Bombs", 0 }
            };

            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> casing = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (effects.Count > 0 && casing.Count > 0)
            {
                int sum = effects.Peek() + casing.Peek();
                if (bombs.ContainsKey(sum))
                {
                    createdBombs[bombs[sum]]++;
                    effects.Dequeue();
                    casing.Pop();
                }
                else
                {
                    casing.Push(casing.Pop() - 5);
                }

                if (createdBombs.Count(x => x.Value >= 3) == 3)
                {
                    break;
                }
            }

            Console.WriteLine(createdBombs.Count(x => x.Value >= 3) == 3
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");
            Console.WriteLine(effects.Count == 0 ? 
                "Bomb Effects: empty" : 
                $"Bomb Effects: {string.Join(", ", effects)}");
            Console.WriteLine(casing.Count == 0 ?
                "Bomb Casings: empty" : 
                $"Bomb Casings: {string.Join(", ", casing)}");
            foreach (var kVP in createdBombs)
            {
                Console.WriteLine($"{kVP.Key}: {kVP.Value}");
            }
        }
    }
}