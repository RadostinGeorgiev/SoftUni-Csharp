namespace _01._Cable_Merchant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int> prices;
        private static int[] bestPrices;
        private static int[] bestLenghts;

        static void Main(string[] args)
        {
            prices = new List<int> { 0 };
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            prices.AddRange(input);

            List<int> bestPprices = new List<int>();

            int connectorPrice = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Count];
            bestLenghts = new int[prices.Count];

            for (int length = 0; length < prices.Count; length++)
            {
                bestPprices.Add(CutRodBestPrice(length, connectorPrice));
            }

            Console.WriteLine(String.Join(' ', bestPprices.Skip(1)));

            //for (int length = 0; length < prices.Count; length++)
            //{
            //    Console.WriteLine(String.Join(' ', GetParts(bestLenghts, length)));
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

            var bestPrice = prices[length];
            var bestLength = length;

            for (int i = 1; i < length / 2 + 1; i++)
            {
                var price = prices[i] + CutRodBestPrice(length - i, connector) - 2 * connector;

                if (price > bestPrice)
                {
                    bestPrice = price;
                    bestLength = i;
                }
            }

            bestPrices[length] = bestPrice;
            bestLenghts[length] = bestLength;

            return bestPrice;
        }
        private static List<int> GetParts(int[] bestParts, int length)
        {
            List<int> parts = new List<int>();

            while (length > 0)
            {
                var currentPart = bestParts[length];
                parts.Add(currentPart);
                length -= currentPart;
            }

            return parts;
        }
    }
}
