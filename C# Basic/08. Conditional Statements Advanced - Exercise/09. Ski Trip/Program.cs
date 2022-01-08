namespace _09._Ski_Trip
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double roomForOnePersonPrice = 18.00;
            const double apartmentPrice = 25.00;
            const double presidentApartmentPrice = 35.00;

            int daysInHotel = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string rate = Console.ReadLine();

            double pricePerNight = 0.00;
            double discount = 0.00;

            switch (typeOfRoom)
            {
                case "room for one person":
                    discount = 0.00;
                    pricePerNight = roomForOnePersonPrice;
                    break;

                case "apartment":
                    if (daysInHotel < 10)
                        discount = 0.30;
                    else if (daysInHotel > 15)
                        discount = 0.50;
                    else
                        discount = 0.35;

                    pricePerNight = apartmentPrice;
                    break;

                case "president apartment":
                    if (daysInHotel < 10)
                        discount = 0.10;
                    else if (daysInHotel > 15)
                        discount = 0.20;
                    else
                        discount = 0.15;

                    pricePerNight = presidentApartmentPrice;
                    break;
            }

            double totalCosts = (daysInHotel - 1) * pricePerNight * (1 - discount);

            if (rate == "positive")
                totalCosts += totalCosts * 0.25;
            else
                totalCosts -= totalCosts * 0.1;

            Console.WriteLine($"{totalCosts:F2}");
        }
    }
}
