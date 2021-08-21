using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double X11 = double.Parse(Console.ReadLine());
            double Y11 = double.Parse(Console.ReadLine());
            double X12 = double.Parse(Console.ReadLine());
            double Y12 = double.Parse(Console.ReadLine());
            double X21 = double.Parse(Console.ReadLine());
            double Y21 = double.Parse(Console.ReadLine());
            double X22 = double.Parse(Console.ReadLine());
            double Y22 = double.Parse(Console.ReadLine());

            PrintLonger(X11, Y11, X12, Y12, X21, Y21, X22, Y22);
        }

        static double Distance(double X1, double Y1, double X2, double Y2)
        {
            return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        }

        static void PrintLineCoordinates(double X1, double Y1, double X2, double Y2)
        {
            if (Distance(X1, Y1, 0, 0) <= Distance(X2, Y2, 0, 0))
            {
                Console.WriteLine($"({X1}, {Y1})({X2}, {Y2})");
            }
            else
            {
                Console.WriteLine($"({X2}, {Y2})({X1}, {Y1})");
            }
        }

        static void PrintLonger(double X11, double Y11, double X12, double Y12,
                                double X21, double Y21, double X22, double Y22)
        {
            if (Distance(X11, Y11, X12, Y12) >= Distance(X21, Y21, X22, Y22))
            {
                PrintLineCoordinates(X11, Y11, X12, Y12);
            }
            else
            {
                PrintLineCoordinates(X21, Y21, X22, Y22);
            }
        }
    }
}
