using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(RaiseNumberToPower(number, power));
        }

        static double RaiseNumberToPower(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
