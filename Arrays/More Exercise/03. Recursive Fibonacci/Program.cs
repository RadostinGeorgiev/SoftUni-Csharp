using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] fibonacciRow = new int[number];
            fibonacciRow[0] = 1;

            if (number > 1)
            {
                fibonacciRow[1] = 1;
            }

            if (number > 2)
            {
                for (int i = 2; i < fibonacciRow.Length; i++)
                {
                    fibonacciRow[i] = fibonacciRow[i - 2] + fibonacciRow[i - 1];
                }
            }

            Console.WriteLine(fibonacciRow[fibonacciRow.Length - 1]);
        }
    }
}
