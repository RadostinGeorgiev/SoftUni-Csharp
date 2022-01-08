namespace _08._Set_Cover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> sets = new List<int[]>();
            List<int> universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            int setsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < setsNumber; i++)
            {
                int[] set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            List<int[]> usedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var currentSet = sets
                    .OrderByDescending(x => x.Count(i => universe.Contains(i)))
                    .FirstOrDefault();

                if (currentSet != null)
                {
                    usedSets.Add(currentSet);

                    foreach (var item in currentSet)
                    {
                        universe.Remove(item);
                    }
                }
            }

            Console.WriteLine($"Sets to take ({usedSets.Count}):");
            foreach (var set in usedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}