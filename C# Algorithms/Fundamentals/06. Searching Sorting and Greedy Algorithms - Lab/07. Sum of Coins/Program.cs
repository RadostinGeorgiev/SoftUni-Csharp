namespace _07._Sum_of_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderBy(c => c)
                .ToArray();
            Stack<int> coins = new Stack<int>(input);
            Dictionary<int, int> usedCoins = new Dictionary<int, int>();

            int targetSum = int.Parse(Console.ReadLine());

            while (targetSum > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Pop();
                var coinsNumber = targetSum / currentCoin;

                if (coinsNumber > 0)
                {
                    usedCoins.Add(currentCoin, coinsNumber);
                }

                targetSum %= currentCoin;
            }

            if (targetSum > 0)
            {
                Console.WriteLine($"Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {usedCoins.Sum(c => c.Value)}");
                foreach (var coin in usedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
        }
    }
}