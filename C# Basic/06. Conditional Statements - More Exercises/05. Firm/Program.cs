using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int numHours = int.Parse(Console.ReadLine());
            int numDays = int.Parse(Console.ReadLine());
            int numStaff = int.Parse(Console.ReadLine());

            double workDays = numDays * 0.1;
            double workHours = workDays * 8 + numDays * numStaff * 2;

            double restHours = workHours - numHours;

            Console.WriteLine(restHours >= 0
                ? $"Yes!{Math.Floor(restHours)} hours left."
                : $"Not enough time!{Math.Abs(Math.Floor(restHours))} hours needed.");
        }
    }
}