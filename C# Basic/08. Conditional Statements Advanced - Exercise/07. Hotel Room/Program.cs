using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int overnight = int.Parse(Console.ReadLine());

            double priceStudio = 0.00;
            double priceApartment = 0.00;
            double discountStudio = 0.00;
            double discountApartment = 0.00;

            switch (month)
            {
                case "May":
                case "October":
                    if (overnight > 7 && overnight <= 14)
                    {
                        discountStudio = 0.05;
                    }
                    else if (overnight > 14)
                    {
                        discountApartment = 0.10;
                        discountStudio = 0.30;
                    }

                    priceApartment = overnight * 65 * (1 - discountApartment);
                    priceStudio = overnight * 50 * (1 - discountStudio);
                    break;

                case "June":
                case "September":
                    if (overnight > 14)
                    {
                        discountApartment = 0.10;
                        discountStudio = 0.20;
                    }

                    priceApartment = overnight * 68.7 * (1 - discountApartment);
                    priceStudio = overnight * 75.2 * (1 - discountStudio);
                    break;

                case "July":
                case "August":
                    if (overnight > 14)
                    {
                        discountApartment = 0.10;
                    }

                    priceApartment = overnight * 77 * (1 - discountApartment);
                    priceStudio = overnight * 76;
                    break;
            }

            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}