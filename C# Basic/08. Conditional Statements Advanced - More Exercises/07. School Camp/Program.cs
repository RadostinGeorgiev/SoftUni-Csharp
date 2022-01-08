using System;

namespace _07._School_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            double price = 0.00;
            string sport = "";
            double discount = 0.00;

            switch (season)
            {
                case "Winter":
                    switch (typeOfGroup)
                    {
                        case "girls":
                            price = 9.6;
                            sport = "Gymnastics";
                            break;

                        case "boys":
                            price = 9.6;
                            sport = "Judo";
                            break;

                        case "mixed":
                            price = 10.0;
                            sport = "Ski";
                            break;
                    }
                    break;

                case "Spring":
                    switch (typeOfGroup)
                    {
                        case "girls":
                            price = 7.2;
                            sport = "Athletics";
                            break;

                        case "boys":
                            price = 7.2;
                            sport = "Tennis";
                            break;

                        case "mixed":
                            price = 9.50;
                            sport = "Cycling";
                            break;
                    }
                    break;

                case "Summer":
                    switch (typeOfGroup)
                    {
                        case "girls":
                            price = 15.0;
                            sport = "Volleyball";
                            break;

                        case "boys":
                            price = 15.0;
                            sport = "Football";
                            break;

                        case "mixed":
                            price = 20.0;
                            sport = "Swimming";
                            break;
                    }
                    break;
            }

            double totalPrice = students * nights * price;

            if (students >= 50)
                discount = 0.5;
            else if (students >= 20)
                discount = 0.15;
            else if (students >= 10)
                discount = 0.05;

            totalPrice -= totalPrice * discount;

            Console.WriteLine($"{sport} {totalPrice:F2} lv.");
        }
    }
}