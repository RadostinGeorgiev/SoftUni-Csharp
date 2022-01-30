namespace _03._Bank_Robbery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static List<int> boxes;
        static void Main(string[] args)
        {
            boxes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int totalGold = boxes.Sum();

            var sums = FindAllSums(boxes);

            var goldForJohn = FindSubset(sums, totalGold / 2);

            Console.WriteLine(string.Join(' ', goldForJohn.OrderBy(x => x)));
            Console.WriteLine(string.Join(' ', boxes.OrderBy(x => x) ));
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);
                boxes.Remove(element);
                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> FindAllSums(List<int> elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

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