using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double workingDayPriceBanana = 2.50;
            const double workingDayPriceApple = 1.20;
            const double workingDayPriceOrange = 0.85;
            const double workingDayPriceGrapefruit = 1.45;
            const double workingDayPriceKiwi = 2.70;
            const double workingDayPricePineapple = 5.50;
            const double workingDayPriceGrapes = 3.85;

            const double holidayPriceBanana = 2.70;
            const double holidayPriceApple = 1.25;
            const double holidayPriceOrange = 0.90;
            const double holidayPriceGrapefruit = 1.60;
            const double holidayPriceKiwi = 3.00;
            const double holidayPricePineapple = 5.60;
            const double holidayPriceGrapes = 4.20;

            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0.00;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = fruit switch
                    {
                        "banana" => workingDayPriceBanana,
                        "apple" => workingDayPriceApple,
                        "orange" => workingDayPriceOrange,
                        "grapefruit" => workingDayPriceGrapefruit,
                        "kiwi" => workingDayPriceKiwi,
                        "pineapple" => workingDayPricePineapple,
                        "grapes" => workingDayPriceGrapes,
                        _ => price
                    };
                    break;
                case "Saturday":
                case "Sunday":
                    price = fruit switch
                    {
                        "banana" => holidayPriceBanana,
                        "apple" => holidayPriceApple,
                        "orange" => holidayPriceOrange,
                        "grapefruit" => holidayPriceGrapefruit,
                        "kiwi" => holidayPriceKiwi,
                        "pineapple" => holidayPricePineapple,
                        "grapes" => holidayPriceGrapes,
                        _ => price
                    };
                    break;
            }

            Console.WriteLine(price != 0 ? $"{quantity * price:f2}" : "error");
        }
    }
}
