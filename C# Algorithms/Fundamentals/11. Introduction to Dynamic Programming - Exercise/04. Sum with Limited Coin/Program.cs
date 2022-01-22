namespace _04._Sum_with_Limited_Coin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSumCount(coins, targetSum));
        }

        private static int GetSumCount(int[] numbers, int target)
        {
            var sums = new HashSet<int> { 0 };
            var counter = 0;

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (newSum == target)
                    {
                        counter++;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return counter;
        }
    }
}