using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            PrintCloser(X1, Y1, X2, Y2);
        }

        static double DistanceToCenter(double X, double Y)
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        static void PrintCloser(double X1, double Y1, double X2, double Y2)
        {
            if (DistanceToCenter(X1, Y1) < DistanceToCenter(X2, Y2))
            {
                Console.WriteLine($"({X1}, {Y1})");
            }
            else
            {
                Console.WriteLine($"({X2}, {Y2})");
            }
        }
    }
}
