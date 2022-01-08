using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;
            double p4 = 0.00;
            double p5 = 0.00;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                    p1++;
                else if (currentNumber <= 399)
                    p2++;
                else if (currentNumber <= 599)
                    p3++;
                else if (currentNumber <= 799)
                    p4++;
                else
                    p5++;
            }

            Console.WriteLine($"{p1 / number * 100:F2}%");
            Console.WriteLine($"{p2 / number * 100:F2}%");
            Console.WriteLine($"{p3 / number * 100:F2}%");
            Console.WriteLine($"{p4 / number * 100:F2}%");
            Console.WriteLine($"{p5 / number * 100:F2}%");
        }
    }
}