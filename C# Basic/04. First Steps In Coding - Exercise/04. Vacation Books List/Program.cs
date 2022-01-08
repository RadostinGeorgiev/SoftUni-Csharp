using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int bookPages = int.Parse(Console.ReadLine());
            int readPagesSpeed = int.Parse(Console.ReadLine());
            int numDays = int.Parse(Console.ReadLine());
            int totalReadHours = bookPages / readPagesSpeed;
            int readPagesDay = totalReadHours / numDays;

            Console.WriteLine(readPagesDay);
        }
    }
}