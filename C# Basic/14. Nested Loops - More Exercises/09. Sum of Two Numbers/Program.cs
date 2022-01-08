using System;

namespace _09._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int intervalStart = int.Parse(Console.ReadLine());
            int intervalEnd = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combination = 0;
            bool foundedNumber = false;

            for (int i = intervalStart; i <= intervalEnd; i++)
            {
                for (int j = intervalStart; j <= intervalEnd; j++)
                {
                    combination++;
                    if (i + j != magicNumber) continue;

                    Console.WriteLine($"Combination N:{combination} ({i} + {j} = {magicNumber})");
                    foundedNumber = true;
                    break;
                }

                if (foundedNumber) break;
            }

            if (!foundedNumber)
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");
            }
        }
    }
}