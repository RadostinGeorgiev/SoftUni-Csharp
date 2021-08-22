using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                PrintNumbersRow(1, i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                PrintNumbersRow(1, i);
            }
        }

        static void PrintNumbersRow(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
