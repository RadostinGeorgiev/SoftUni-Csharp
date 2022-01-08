namespace BasketballEquipment
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());

            double sneakersPrice = annualFee * (1 - 0.4);
            double outfitPrice = sneakersPrice * (1 - 0.2);
            double ballPrice = outfitPrice / 4;
            double accessoriesPrice = ballPrice / 5;

            double totalAmount = annualFee + sneakersPrice + outfitPrice + ballPrice + accessoriesPrice;

            Console.WriteLine(totalAmount);
        }
    }
}