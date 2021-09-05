using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split());
            int rowIndex = 0;
            int colIndex = 0;
            char[,] matrix = CreateMatrixFixStart(size, ref rowIndex, ref colIndex);

            while (commands.Count > 0)
            {
                MinerMove(commands.Dequeue(), matrix, ref rowIndex, ref colIndex);
                switch (matrix[rowIndex, colIndex])
                {
                    case 'c':
                        matrix[rowIndex, colIndex] = '*';

                        if (matrix.Cast<char>().Count(c => c == 'c') == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                            return;
                        }
                        break;
                    case 'e':
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                }
            }

            Console.WriteLine($"{matrix.Cast<char>().Count(c => c == 'c')} coals left. ({rowIndex}, {colIndex})");
        }

        private static char[,] CreateMatrixFixStart(int size, ref int rowIndex, ref int colIndex)
        {
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 's')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            return matrix;
        }

        private static void MinerMove(string command, char[,] matrix, ref int rowIndex, ref int colIndex)
        {
            switch (command)
            {
                case "left":
                    colIndex--;
                    if (colIndex < 0)
                    {
                        colIndex = 0;
                    }
                    break;
                case "right":
                    colIndex++;
                    if (colIndex == matrix.GetLength(1))
                    {
                        colIndex = matrix.GetLength(1) - 1;
                    }
                    break;
                case "up":
                    rowIndex--;
                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }
                    break;
                case "down":
                    rowIndex++;
                    if (rowIndex == matrix.GetLength(0))
                    {
                        rowIndex = matrix.GetLength(0) - 1;
                    }
                    break;
            }
        }
    }
}
