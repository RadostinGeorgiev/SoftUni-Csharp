using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int columns = size[1];
            int indexRow = 0;
            int indexCol = 0;

            char[,] matrix = CreateMatrixFixStart(rows, columns, ref indexRow, ref indexCol);

            string commands = Console.ReadLine();
            for (int pos = 0; pos < commands.Length; pos++)
            {
                char newPlayerPos = PlayerMove(commands[pos], matrix, ref indexRow, ref indexCol);
                matrix = IncreaseBunny(matrix);

                switch (newPlayerPos)
                {
                    case 'P':
                        if (matrix.Cast<char>().Any(c => c == 'P') == false)
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {indexRow} {indexCol}");
                            return;
                        }
                        break;
                    case 'W':
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {indexRow} {indexCol}");
                        return;
                    case 'B':
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {indexRow} {indexCol}");
                        return;
                }
            }
        }

        private static char[,] CreateMatrixFixStart(int rows, int columns, ref int indexRow, ref int indexCol)
        {
            char[,] matrix = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'P')
                    {
                        indexRow = row;
                        indexCol = col;
                    }
                }
            }

            return matrix;
        }

        private static char PlayerMove(char command, char[,] matrix, ref int rowIndex, ref int colIndex)
        {
            matrix[rowIndex, colIndex] = '.';
            switch (command)
            {
                case 'L':
                    colIndex--;
                    if (colIndex < 0)
                    {
                        colIndex = 0;
                        return 'W';
                    }
                    break;
                case 'R':
                    colIndex++;
                    if (colIndex == matrix.GetLength(1))
                    {
                        colIndex = matrix.GetLength(1) - 1;
                        return 'W';
                    }
                    break;
                case 'U':
                    rowIndex--;
                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                        return 'W';
                    }
                    break;
                case 'D':
                    rowIndex++;
                    if (rowIndex == matrix.GetLength(0))
                    {
                        rowIndex = matrix.GetLength(0) - 1;
                        return 'W';
                    }
                    break;
            }

            if (matrix[rowIndex, colIndex] == 'B')
            {
                return 'B';
            }

            matrix[rowIndex, colIndex] = 'P';
            return 'P';
        }

        private static bool CheckCoordinateInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static char[,] IncreaseBunny(char[,] matrix)
        {
            char[,] newMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (CheckCoordinateInRange(matrix, row - 1, col))
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (CheckCoordinateInRange(matrix, row, col - 1))
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (CheckCoordinateInRange(matrix, row, col + 1))
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                        if (CheckCoordinateInRange(matrix, row + 1, col))
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
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

    }
}