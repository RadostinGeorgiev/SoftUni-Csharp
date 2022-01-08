using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSoldSeats = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;

            string movie;
            while ((movie = Console.ReadLine()) != "Finish")
            {
                int totalSeats = int.Parse(Console.ReadLine());
                int soldSeats = 0;

                string tickedType;
                while (soldSeats != totalSeats &&
                       (tickedType = Console.ReadLine()) != "End" &&
                       tickedType != "Finish")
                {
                    soldSeats++;

                    switch (tickedType)
                    {
                        case "student": studentTickets++; break;
                        case "standard": standardTickets++; break;
                        case "kid": kidsTickets++; break;
                    }
                }

                Console.WriteLine($"{movie} - {(double)soldSeats / totalSeats * 100:F2}% full.");
                totalSoldSeats += soldSeats;
            }

            Console.WriteLine($"Total tickets: {totalSoldSeats}");
            Console.WriteLine($"{(double)studentTickets / totalSoldSeats * 100:F2}% student tickets.");
            Console.WriteLine($"{(double)standardTickets / totalSoldSeats * 100:F2}% standard tickets.");
            Console.WriteLine($"{(double)kidsTickets / totalSoldSeats * 100:F2}% kids tickets.");
        }
    }
}