using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> products =
                new SortedDictionary<string, Dictionary<string, double>>();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!products.ContainsKey(shop))
                {
                    products.Add(shop, new Dictionary<string, double>());
                }

                products[shop].Add(product, price);
            }

            foreach (var kVP in products)
            {
                Console.WriteLine($"{kVP.Key}->");
                foreach (var keyValuePair in kVP.Value)
                {
                    Console.WriteLine($"Product: {keyValuePair.Key}, Price: {keyValuePair.Value}");
                }
            }
        }
    }
}
