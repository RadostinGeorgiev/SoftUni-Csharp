using System;

namespace _02._Bike_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string typeRunaway = Console.ReadLine();

            double tax = 0.00;
            switch (typeRunaway)
            {
                case "trail":
                    tax = juniors * 5.50 + seniors * 7.0;
                    break;

                case "cross-country":
                    tax = juniors * 8.0 + seniors * 9.50;
                    if ((juniors + seniors) >= 50)
                        tax = tax * 0.75;
                    break;

                case "downhill":
                    tax = juniors * 12.25 + seniors * 13.75;
                    break;

                case "road":
                    tax = juniors * 20.0 + seniors * 21.5;
                    break;
            }

            double costs = tax * 0.05;

            Console.WriteLine($"{tax - costs:F2}");
        }
    }
}