using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = sizeMatrix[0];
            int columns = sizeMatrix[1];
            char[,] matrix = new char[rows, columns];
            string snake = Console.ReadLine();
            int snakePiece = 0;

            for (int row = 0; row < rows; row += 2)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = GetSnakeElement(snake, ref snakePiece);
                }

                if (row + 1 < rows)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row + 1, col] = GetSnakeElement(snake, ref snakePiece);
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char GetSnakeElement(string snake, ref int snakePiece)
        {
            char piece = snake[snakePiece];
            snakePiece++;
            if (snakePiece == snake.Length)
            {
                snakePiece = 0;
            }

            return piece;
        }
    }
}
