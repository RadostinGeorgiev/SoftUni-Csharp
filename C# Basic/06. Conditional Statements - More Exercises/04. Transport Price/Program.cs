using System;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            const double priceTaxiStart = 0.70;
            const double priceTaxiDay = 0.79;
            const double priceTaxiNight = 0.9;
            const double priceBus = 0.09;
            const double priceTrain = 0.06;
            double price = 0.00;

            if (kilometers >= 100)
            {
                price = kilometers * priceTrain;
            }
            else if (kilometers >= 20)
            {
                price = kilometers * priceBus;
            }
            else
            {
                if (dayOrNight == "day")
                {
                    price = priceTaxiStart + kilometers * priceTaxiDay;
                }
                else if (dayOrNight == "night")
                {
                    price = priceTaxiStart + kilometers * priceTaxiNight;
                }
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}