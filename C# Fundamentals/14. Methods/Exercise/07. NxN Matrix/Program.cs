using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            PrintMatrix(number);
        }

        static void PrintMatrix(int input)
        {
            for (int row = 1; row <= input; row++)
            {
                for (int cols = 1; cols <= input; cols++)
                {
                    Console.Write(input + " ");
                }

                Console.WriteLine();
            }
        }
    }

}
