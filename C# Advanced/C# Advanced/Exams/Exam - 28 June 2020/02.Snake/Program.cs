using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int rowS = 0;
            int colS = 0;
            int rowBurrowOne = 0;
            int colBurrowOne = 0;
            int rowBurrowTwo = 0;
            int colBurrowTwo = 0;
            int foodCounter = 0;

            FillMatrix(size, matrix,
                ref rowS, ref colS,
                    ref rowBurrowOne, ref colBurrowOne,
                    ref rowBurrowTwo, ref colBurrowTwo);

            while (foodCounter < 10)
            {
                string command = Console.ReadLine();

                if (MoveSnake(matrix, command, ref rowS, ref colS))
                {
                    foodCounter += ActionSnake(matrix,
                        ref rowS, ref colS,
                        rowBurrowOne, colBurrowOne,
                        rowBurrowTwo, colBurrowTwo);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(foodCounter >= 10 ? "You won! You fed the snake." : "Game over!");
            Console.WriteLine($"Food eaten: {foodCounter}");

            PrintMatrix(matrix);
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

        private static bool MoveSnake(char[,] matrix, string command, ref int rowS, ref int colS)
        {
            matrix[rowS, colS] = '.';
            switch (command)
            {
                case "up": rowS--; break;
                case "down": rowS++; break;
                case "left": colS--; break;
                case "right": colS++; break;
            }

            return CheckCoordinates(matrix, rowS, colS);
        }

        private static int ActionSnake(char[,] matrix, ref int rowS, ref int colS, int rowBurrowOne, int colBurrowOne, int rowBurrowTwo, int colBurrowTwo)
        {
            int food = 0;
            char currentChar = matrix[rowS, colS];
            switch (currentChar)
            {
                case '*':
                    food++;
                    break;
                case 'B':
                    matrix[rowS, colS] = '.';

                    if (rowS == rowBurrowOne && colS == colBurrowOne)
                    {
                        rowS = rowBurrowTwo;
                        colS = colBurrowTwo;
                    }
                    else
                    {
                        rowS = rowBurrowOne;
                        colS = colBurrowOne;
                    }
                    break;
            }

            matrix[rowS, colS] = 'S';
            return food;
        }

        private static bool CheckCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(int size, char[,] matrix,
            ref int rowS, ref int colS,
            ref int rowBurrowOne, ref int colBurrowOne,
            ref int rowBurrowTwo, ref int colBurrowTwo)
        {
            bool isBurrowFound = false;
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        rowS = row;
                        colS = col;
                    }

                    if (currentRow[col] == 'B')
                    {
                        if (!isBurrowFound)
                        {
                            rowBurrowOne = row;
                            colBurrowOne = col;
                            isBurrowFound = true;
                        }
                        else
                        {
                            rowBurrowTwo = row;
                            colBurrowTwo = col;
                        }
                    }
                }
            }
        }
    }
}