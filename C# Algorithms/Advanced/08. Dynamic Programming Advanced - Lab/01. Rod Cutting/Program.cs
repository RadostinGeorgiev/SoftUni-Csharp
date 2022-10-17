namespace _01._Rod_Cutting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[] prices;
        private static int[] bestPrices;
        private static int[] bestLengths;

        static void Main(string[] args)
        {
            prices = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int length = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Length];
            bestLengths = new int[prices.Length];

            Console.WriteLine(CutRodBestPrice(length));
            Console.WriteLine(string.Join(" ", GetParts(bestLengths, length)));
        }

        private static int CutRodBestPrice(int length)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            int bestPrice = prices[length];
            int bestLength = length;

            for (int i = 1; i < length / 2 + 1; i++)
            {
                int price = prices[i] + CutRodBestPrice(length - i);

                if (price > bestPrice)
                {
                    bestPrice = price;
                    bestLength = i;
                }
            }

            bestPrices[length] = bestPrice;
            bestLengths[length] = bestLength;

            return bestPrice;
        }

        private static List<int> GetParts(int[] bestParts, int length)
        {
            List<int> parts = new List<int>();

            while (length > 0)
            {
                int currentPart = bestParts[length];
                parts.Add(currentPart);
                length -= currentPart;
            }

            return parts;
        }
    }
}