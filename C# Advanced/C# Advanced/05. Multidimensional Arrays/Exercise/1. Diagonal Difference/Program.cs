using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }
                    if (size - 1 - row == col)
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
