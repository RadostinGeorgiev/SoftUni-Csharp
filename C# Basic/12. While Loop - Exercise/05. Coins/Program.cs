using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine()) * 100;

            int restCoins = (int)money;
            int coins = 0;

            while (restCoins >= 200)
            {
                restCoins -= 200;
                coins++;
            }

            while (restCoins >= 100)
            {
                restCoins -= 100;
                coins++;
            }

            while (restCoins >= 50)
            {
                restCoins -= 50;
                coins++;
            }

            while (restCoins >= 20)
            {
                restCoins -= 20;
                coins++;
            }

            while (restCoins >= 10)
            {
                restCoins -= 10;
                coins++;
            }

            while (restCoins >= 5)
            {
                restCoins -= 5;
                coins++;
            }

            while (restCoins >= 2)
            {
                restCoins -= 2;
                coins++;
            }

            coins += restCoins;
            Console.WriteLine(coins);
        }
    }
}