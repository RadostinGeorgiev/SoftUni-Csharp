using System;

namespace Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());

            const int gameInWorkDays = 63;
            const int gameInHolidays = 127;

            int workDays = 365 - holidays;

            int totalGameTime = workDays * gameInWorkDays + holidays * gameInHolidays;
            int timeDifference = Math.Abs(totalGameTime - 30000);

            if (totalGameTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{timeDifference/60} hours and {timeDifference % 60} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{timeDifference / 60} hours and {timeDifference % 60} minutes less for play");
            }
        }
    }
}