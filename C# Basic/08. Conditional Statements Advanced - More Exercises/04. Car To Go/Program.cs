using System;

namespace _04._Car_To_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double priceOfCar = 0.00;

            string classOfCar;
            string typeOfCar = "";

            if (budget <= 100)
            {
                classOfCar = "Economy class";

                switch (season)
                {
                    case "Summer":
                        typeOfCar = "Cabrio";
                        priceOfCar = budget * 0.35;
                        break;

                    case "Winter":
                        typeOfCar = "Jeep";
                        priceOfCar = budget * 0.65;
                        break;
                }
            }
            else if (budget > 500)
            {
                classOfCar = "Luxury class";
                typeOfCar = "Jeep";
                priceOfCar = budget * 0.9;
            }
            else
            {
                classOfCar = "Compact class";

                switch (season)
                {
                    case "Summer":
                        typeOfCar = "Cabrio";
                        priceOfCar = budget * 0.45;
                        break;

                    case "Winter":
                        typeOfCar = "Jeep";
                        priceOfCar = budget * 0.8;
                        break;
                }
            }

            Console.WriteLine($"{classOfCar}");
            Console.WriteLine($"{typeOfCar} - {priceOfCar:F2}");
        }
    }
}