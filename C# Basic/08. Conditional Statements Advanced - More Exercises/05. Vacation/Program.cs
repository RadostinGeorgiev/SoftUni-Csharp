using System;

namespace _05._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double totalPrice = 0.00;

            string place;
            string location = "";
            if (budget <= 1000)
            {
                place = "Camp";

                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        totalPrice = budget * 0.65;
                        break;

                    case "Winter":
                        location = "Morocco";
                        totalPrice = budget * 0.45;
                        break;
                }
            }
            else if (budget > 3000)
            {
                place = "Hotel";

                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        break;

                    case "Winter":
                        location = "Morocco";
                        break;
                }
                totalPrice = budget * 0.9;
            }
            else
            {
                place = "Hut";

                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        totalPrice = budget * 0.8;
                        break;

                    case "Winter":
                        location = "Morocco";
                        totalPrice = budget * 0.6;
                        break;
                }
            }

            Console.WriteLine($"{location} - {place} - {totalPrice:F2}");
        }
    }
}