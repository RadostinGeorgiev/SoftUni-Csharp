using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            string input = Console.ReadLine();
            List<string> purchase = new List<string>();
            double sum = 0;
            while (input != "Purchase")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    purchase.Add(Regex.Match(input, pattern).Groups["name"].Value);
                    double price = double.Parse(Regex.Match(input, pattern).Groups["price"].Value);
                    int quantity = int.Parse(Regex.Match(input, pattern).Groups["quantity"].Value);
                    sum += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (purchase.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, purchase));
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
