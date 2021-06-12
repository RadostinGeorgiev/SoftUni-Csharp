using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine($"{CalculateOrder(productType, quantity):f2}");
        }

        static double CalculateOrder(string product, int quantity)
        {
            const double coffee = 1.50;
            const double water = 1.00;
            const double coke = 1.40;
            const double snacks = 2.00;

            switch (product)
            {
                case "coffee":
                    return coffee * quantity;
                    break;
                case "coke":
                    return coke * quantity;
                    break;
                case "water":
                    return water * quantity;
                    break;
                case "snacks":
                    return snacks * quantity;
                    break;
                default:
                    return 0.00;
            }
        }
    }
}
