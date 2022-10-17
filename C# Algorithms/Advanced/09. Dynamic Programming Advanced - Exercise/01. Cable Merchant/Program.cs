namespace _01._Cable_Merchant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int> prices;
        private static int[] bestPrices;
        private static int[] bestLengths;

        static void Main(string[] args)
        {
            prices = new List<int> { 0 };                                           //dummy index to equalize length and price indexes

            int[] input = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            prices.AddRange(input);
            int connectorPrice = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Count];
            bestLengths = new int[prices.Count];

            List<int> maximumPrices = new List<int>();

            for (int length = 0; length < prices.Count; length++)
            {
                maximumPrices.Add(CutRodBestPrice(length, connectorPrice));
            }

            Console.WriteLine(string.Join(" ", maximumPrices.Skip(1)));

            //for (int length = 0; length < prices.Count; length++)
            //{
            //    Console.WriteLine(string.Join(' ', GetParts(bestLengths, length)));
            //}
        }

        private static int CutRodBestPrice(int length, int connector)
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
                int price = prices[i] + CutRodBestPrice(length - i, connector) - 2 * connector;

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