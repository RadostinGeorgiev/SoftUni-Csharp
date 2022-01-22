namespace _03._Sum_with_Unlimited_Co
{
    using System;
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
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var number in numbers)
            {
                for (int i = number; i <= target; i++)
                {
                    sums[i] += sums[i - number];
                }
            }

            return sums[target];
        }
    }
}