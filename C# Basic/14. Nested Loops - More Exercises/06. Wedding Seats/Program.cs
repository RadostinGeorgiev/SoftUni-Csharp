using System;

namespace _06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char endSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int seatsInOddRow = int.Parse(Console.ReadLine());
            int totalSeats = 0;

            for (int sector = 'A'; sector <= endSector; sector++)
            {
                for (int row = 1; row <= rowsInFirstSector; row++)
                {
                    int seatsInCurrentRow = seatsInOddRow;

                    if (row % 2 == 0) seatsInCurrentRow += 2;

                    for (int seat = 0; seat < seatsInCurrentRow; seat++)
                    {
                        totalSeats++;
                        Console.WriteLine($"{Convert.ToChar(sector)}{row}{Convert.ToChar('a' + seat)}");
                    }
                }

                rowsInFirstSector++;
            }

            Console.WriteLine(totalSeats);
        }
    }
}