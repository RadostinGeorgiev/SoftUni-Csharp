using System;

namespace _07._House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            const double costSidesGreen = 3.4;
            const double costRoofRed = 4.3;

            double heightHouse = double.Parse(Console.ReadLine());
            double lenghtHouse = double.Parse(Console.ReadLine());
            double heightRoof = double.Parse(Console.ReadLine());
            double widthHouse = heightHouse;

            double areaSides = (2 * heightHouse * widthHouse - 1.2 * 2) + (2 * heightHouse * lenghtHouse - 2 * 1.5 * 1.5);
            double areaRoof = (2 * heightHouse * lenghtHouse) + (2 * widthHouse * heightRoof / 2);

            Console.WriteLine($"{areaSides / costSidesGreen:F2}");
            Console.WriteLine($"{areaRoof / costRoofRed:F2}");
        }
    }
}