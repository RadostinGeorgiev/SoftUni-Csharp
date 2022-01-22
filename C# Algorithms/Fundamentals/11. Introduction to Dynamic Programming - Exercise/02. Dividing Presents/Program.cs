namespace _02._Dividing_Presents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int total = presents.Sum();

            var sums = FindAllSums(presents);
            var sumForAlan = total / 2;

            while (true)
            {
                if (sums.ContainsKey(sumForAlan))
                {
                    var sumForBob = total - sumForAlan;
                    var presentsForAlan = FindSubset(sums, sumForAlan);

                    Console.WriteLine($"Difference: {sumForBob - sumForAlan}");
                    Console.WriteLine($"Alan:{sumForAlan} Bob:{sumForBob}");
                    Console.WriteLine($"Alan takes: {string.Join(' ', presentsForAlan)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                sumForAlan--;
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);
                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> {{0,0}};

            foreach (var element in elements)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var currentSum in currentSums)
                {
                    var newSum = currentSum + element;

                    if (sums.ContainsKey(newSum)) continue;

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}