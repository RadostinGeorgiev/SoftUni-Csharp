using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dishes = new Dictionary<int, string>()
            {
                { 150, "Dipping sauce" },
                { 250, "Green salad" },
                { 300, "Chocolate cake" },
                { 400, "Lobster" }
            };
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> madeDishes = new Dictionary<string, int>();


            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int dish = ingredients.Peek() * freshness.Pop();
                if (dishes.ContainsKey(dish))
                {
                    var dishType = dishes[dish];
                    ingredients.Dequeue();

                    if (!madeDishes.ContainsKey(dishType))
                    {
                        madeDishes.Add(dishType, 0);
                    }

                    madeDishes[dishType]++;
                }
                else
                {
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            Console.WriteLine(madeDishes.Count == 4
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var kVP in madeDishes.OrderBy(x=>x.Key))
            {
                Console.WriteLine($" # {kVP.Key} --> {kVP.Value}");
            }
        }
    }
}