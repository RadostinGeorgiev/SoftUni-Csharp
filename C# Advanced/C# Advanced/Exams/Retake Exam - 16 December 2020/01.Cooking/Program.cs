using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<int, string> recipe = new Dictionary<int, string>()
                  { { 25, "Bread" },
                    { 50, "Cake" },
                    { 75, "Pastry" },
                    { 100, "Fruit Pie" } };

            SortedDictionary<string, int> cockedFoods = new SortedDictionary<string, int>()
                    { { "Bread", 0 },
                    { "Cake", 0 },
                    { "Pastry", 0 },
                    { "Fruit Pie", 0 } };
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();
                int mix = currentLiquid + currentIngredient;

                if (recipe.ContainsKey(mix))
                {
                    cockedFoods[recipe[mix]]++;
                }
                else
                {
                    ingredients.Push(currentIngredient + 3);
                }
            }

            Console.WriteLine(!cockedFoods.Values.Contains(0)
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");
            Console.WriteLine(liquids.Count == 0
                ? "Liquids left: none"
                : $"Liquids left: {string.Join(", ", liquids)}");
            Console.WriteLine(ingredients.Count == 0
                ? "Ingredients left: none"
                : $"Ingredients left: {string.Join(", ", ingredients)}");
            foreach (var food in cockedFoods)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}