using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                    p1++;
                if (currentNumber % 3 == 0)
                    p2++;
                if (currentNumber % 4 == 0)
                    p3++;
            }

            Console.WriteLine($"{p1 / number * 100:F2}%");
            Console.WriteLine($"{p2 / number * 100:F2}%");
            Console.WriteLine($"{p3 / number * 100:F2}%");
        }
    }
}