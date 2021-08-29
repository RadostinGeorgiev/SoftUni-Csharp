using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sum = 0;
            for (int cell = 0; cell < size; cell++)
            {
                sum += matrix[cell, cell];
            }

            Console.WriteLine(sum);
        }
    }
}
