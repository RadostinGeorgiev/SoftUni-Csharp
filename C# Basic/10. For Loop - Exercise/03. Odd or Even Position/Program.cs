using System;

namespace _03._Odd_or_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double oddSum = 0.00;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;
            double evenSum = 0.00;


            for (int i = 1; i <= number; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    if (currentNumber > evenMax)
                        evenMax = currentNumber;

                    if (currentNumber < evenMin)
                        evenMin = currentNumber;

                    evenSum += currentNumber;
                }
                else
                {
                    if (currentNumber > oddMax)
                        oddMax = currentNumber;

                    if (currentNumber < oddMin)
                        oddMin = currentNumber;

                    oddSum += currentNumber;
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");

            if (oddSum == 0.00)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
                Console.WriteLine($"OddMax={oddMax:F2},");
            }

            Console.WriteLine($"EvenSum={evenSum:F2},");

            if (evenSum == 0.00)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
        }
    }
}