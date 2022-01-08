namespace Repainting
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double nylonPrice = 1.50;
            const double paintPrice = 14.50;
            const double thinnerPrice = 5.00;
            const double bagsPrice = 0.40;

            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            double totalAmount = (nylon + 2) * nylonPrice + paint * 1.1 * paintPrice + thinner * thinnerPrice + bagsPrice;
            totalAmount += totalAmount * 0.30 * hoursWork;

            Console.WriteLine($"{totalAmount:F2}");
        }
    }
}