using System;

namespace _9._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            const int totalWeekends = 48;
            string year = Console.ReadLine();
            double holidaysInYear = double.Parse(Console.ReadLine());
            double weekendsInHometown = double.Parse(Console.ReadLine());

            double weekendsInSofia = totalWeekends - weekendsInHometown;
            double freeWeekendsInSofia = weekendsInSofia * 3 / 4;
            double gamesInHolidays = holidaysInYear * 2 / 3;
            double totalGames = freeWeekendsInSofia + gamesInHolidays + weekendsInHometown;

            if (year == "leap")
                totalGames += totalGames * 0.15;

            totalGames = Math.Floor(totalGames);

            Console.WriteLine(totalGames);
        }
    }
}