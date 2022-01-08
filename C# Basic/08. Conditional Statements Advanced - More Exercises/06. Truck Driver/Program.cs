using System;

namespace _06._Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometers = double.Parse(Console.ReadLine());

            double salary = 0.00;

            if (kilometers <= 5000)
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        salary = 4 * kilometers * 0.75;
                        break;
                    case "Summer":
                        salary = 4 * kilometers * 0.9;
                        break;
                    case "Winter":
                        salary = 4 * kilometers * 1.05;
                        break;
                }
            else if (kilometers <= 10000)
                switch (season)
                {

                    case "Spring":
                    case "Autumn":
                        salary = 4 * kilometers * 0.95;
                        break;
                    case "Summer":
                        salary = 4 * kilometers * 1.1;
                        break;
                    case "Winter":
                        salary = 4 * kilometers * 1.25;
                        break;
                }
            else if (kilometers <= 20000)
                salary = 4 * kilometers * 1.45;

            salary -= salary * 0.1;

            Console.WriteLine($"{salary:F2}");
        }
    }
}