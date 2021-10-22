using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int rowB = 0;
            int colB = 0;
            int polinationedFlowers = 0;

            FillMatrix(size, matrix, ref rowB, ref colB);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (!MoveBee(matrix, ref rowB, ref colB, command, ref polinationedFlowers))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            Console.WriteLine(polinationedFlowers < 5
                ? $"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowers} flowers more"
                : $"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");

            PrintMatrix( matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool MoveBee(char[,] matrix, ref int rowB, ref int colB, string command, ref int counter)
        {
            matrix[rowB, colB] = '.';

            switch (command)
            {
                case "up": rowB--; break;
                case "down": rowB++; break;
                case "left": colB--; break;
                case "right": colB++; break;
            }

            if (CheckCoordinates(matrix, rowB, colB))
            {
                if (matrix[rowB, colB] == 'f')
                {
                    matrix[rowB, colB] = '.';
                    counter++;
                }
                else if (matrix[rowB, colB] == 'O')
                {
                    MoveBee(matrix, ref rowB, ref colB, command, ref counter);
                }

                matrix[rowB, colB] = 'B';
                return true;
            }

            return false;
        }

        private static bool CheckCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && 
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(int size, char[,] matrix, ref int rowB, ref int colB)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        rowB = row;
                        colB = col;
                    }
                }
            }
        }
    }
}