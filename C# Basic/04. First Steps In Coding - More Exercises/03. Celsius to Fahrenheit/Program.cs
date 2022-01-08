using System;

namespace _03._Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double degreeC = double.Parse(Console.ReadLine());

            double degreeF = degreeC * 1.8 + 32;

            Console.WriteLine($"{degreeF:F2}");
        }
    }
}