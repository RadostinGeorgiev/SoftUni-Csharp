namespace SuppliesForSchool
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double penPrice = 5.80;
            const double markerPrice = 7.20;
            const double detergentPrice = 1.20;

            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int detergent = int.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double totalAmount = (pens * penPrice + markers * markerPrice + detergent * detergentPrice);
            totalAmount *= 1- discountPercentage / 100.0;

            Console.WriteLine(totalAmount);
        }
    }
}