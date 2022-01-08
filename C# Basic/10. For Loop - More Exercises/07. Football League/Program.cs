using System;

namespace _07._Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int fansTotal = int.Parse(Console.ReadLine());

            int fansInSectorA = 0;
            int fansInSectorB = 0;
            int fansInSectorV = 0;
            int fansInSectorG = 0;

            for (int i = 0; i < fansTotal; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A":
                        fansInSectorA++;
                        break;

                    case "B":
                        fansInSectorB++;
                        break;

                    case "V":
                        fansInSectorV++;
                        break;

                    case "G":
                        fansInSectorG++;
                        break;
                }
            }

            Console.WriteLine($"{1.0 * fansInSectorA / fansTotal * 100:F2}%");
            Console.WriteLine($"{1.0 * fansInSectorB / fansTotal * 100:F2}%");
            Console.WriteLine($"{1.0 * fansInSectorV / fansTotal * 100:F2}%");
            Console.WriteLine($"{1.0 * fansInSectorG / fansTotal * 100:F2}%");
            Console.WriteLine($"{1.0 * fansTotal / stadiumCapacity * 100:F2}%");
        }
    }
}