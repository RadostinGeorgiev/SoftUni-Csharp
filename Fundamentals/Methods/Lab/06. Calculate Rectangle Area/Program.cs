using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = int.Parse(Console.ReadLine());
            double length = int.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(width, length));
        }

        static double RectangleArea(double width, double length)
        {
            return width * length;
        }
    }
}
