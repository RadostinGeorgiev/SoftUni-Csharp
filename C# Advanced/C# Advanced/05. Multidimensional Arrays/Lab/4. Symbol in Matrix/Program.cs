using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char symbol = Char.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }

                }

            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
