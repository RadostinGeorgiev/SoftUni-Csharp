using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "mm")
            {
                if (outputUnit == "cm")
                {
                    number = number / 10;
                }
                else if (outputUnit == "m")
                {
                    number = number / 1000;
                }
            }
            else if (inputUnit == "cm")
            {
                if (outputUnit == "mm")
                {
                    number = number * 10;
                }
                else if (outputUnit == "m")
                {
                    number = number / 100;
                }
            }
            else if (inputUnit == "m")
            {
                if (outputUnit == "mm")
                {
                    number = number * 1000;
                }
                else if (outputUnit == "cm")
                {
                    number = number * 100;
                }
            }
            Console.WriteLine($"{number:F3}");
        }
    }
}