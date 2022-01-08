using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());

            double totalScores = 0.0;
            int numbersTo9 = 0;
            int numbersTo19 = 0;
            int numbersTo29 = 0;
            int numbersTo39 = 0;
            int numbersTo50 = 0;
            int numbersInvalid = 0;

            for (int i = 0; i < moves; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 0 || currentNumber > 50)
                {
                    numbersInvalid++;
                    totalScores *= 0.5;
                }
                else if (currentNumber <= 9)
                {
                    numbersTo9++;
                    totalScores += currentNumber * 0.2;
                }
                else if (currentNumber <= 19)
                {
                    numbersTo19++;
                    totalScores += currentNumber * 0.3;
                }
                else if (currentNumber <= 29)
                {
                    numbersTo29++;
                    totalScores += currentNumber * 0.4;
                }
                else if (currentNumber <= 39)
                {
                    numbersTo39++;
                    totalScores += 50;
                }
                else if (currentNumber <= 50)
                {
                    numbersTo50++;
                    totalScores += 100;
                }
            }

            Console.WriteLine($"{totalScores:F2}");
            Console.WriteLine($"From 0 to 9: {1.0 * numbersTo9 / moves * 100:F2}%");
            Console.WriteLine($"From 10 to 19: {1.0 * numbersTo19 / moves * 100:F2}%");
            Console.WriteLine($"From 20 to 29: {1.0 * numbersTo29 / moves * 100:F2}%");
            Console.WriteLine($"From 30 to 39: {1.0 * numbersTo39 / moves * 100:F2}%");
            Console.WriteLine($"From 40 to 50: {1.0 * numbersTo50 / moves * 100:F2}%");
            Console.WriteLine($"Invalid numbers: {1.0 * numbersInvalid / moves * 100:F2}%");
        }
    }
}