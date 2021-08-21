using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] item = input.Split();
                string productName = item[0];
                double price = double.Parse(item[1]);
                double quantity = double.Parse(item[2]);

                if (products.ContainsKey(productName))
                {
                    products[productName][0] = price;
                    products[productName][1] += quantity;
                }
                else
                {
                    products.Add(productName, new double[] { price, quantity });
                }

                input = Console.ReadLine();
            }

            foreach (var keyValuePair in products)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value[0] * keyValuePair.Value[1]:F2}");
            }
        }
    }
}
