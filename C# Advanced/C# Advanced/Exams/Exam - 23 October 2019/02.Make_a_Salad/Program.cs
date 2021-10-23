using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Make_a_Salad
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> calories = new Dictionary<string, int>()
            {
                { "tomato", 80},
                { "carrot", 136},
                { "lettuce", 109},
                { "potato", 215}
            };

            Queue<string> vegetables = new Queue<string>(Console.ReadLine().Split());
            Stack<int> salads = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> readySalads = new List<int>();

            while (vegetables.Count > 0 && salads.Count > 0)
            {
                int currentSalad = salads.Peek();

                while (currentSalad > 0)
                {
                    if (vegetables.Count == 0)
                    {
                        break;
                    }
                    currentSalad -= calories[vegetables.Dequeue()];
                }
                readySalads.Add(salads.Pop());
            }

            Console.WriteLine(string.Join(' ', readySalads));
            Console.WriteLine(vegetables.Count == 0 
                ? string.Join(' ', salads) 
                : string.Join(' ', vegetables));
        }
    }
}