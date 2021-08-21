using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            string pattern = @"^[^|.$%]*%(?<name>[A-Z][a-z]+)%(?:[^|.$%]*)<(?<product>\w+)\>(?:[^|.$%]*)\|(?<count>\d+)\|(?:[^|.$%]*?)(?<price>\d+\.?\d*)[$][^|.$%]*$";
            double income = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    string customerName = Regex.Match(input, pattern).Groups["name"].Value;
                    string product = Regex.Match(input, pattern).Groups["product"].Value;
                    int quantity = int.Parse(Regex.Match(input, pattern).Groups["count"].Value);
                    double price = double.Parse(Regex.Match(input, pattern).Groups["price"].Value);
                    Console.WriteLine($"{customerName}: {product} - {quantity * price:F2}");
                    income += quantity * price;
                }
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
