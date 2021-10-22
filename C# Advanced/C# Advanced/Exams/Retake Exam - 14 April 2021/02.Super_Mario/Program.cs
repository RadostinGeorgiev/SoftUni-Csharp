using System;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] maze = new char[rows][];
            int rowMario = 0;
            int colMario = 0;

            CreateMatrix(maze, ref rowMario, ref colMario);

            while (lives > 0)
            {
                var command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int rowE = int.Parse(command[1]);
                int colE = int.Parse(command[2]);
                SpawnEnemy(maze, rowE, colE);

                if (MarioMove(maze, command[0], ref rowMario, ref colMario, ref lives))
                {
                    break;
                }
            }

            Console.WriteLine(lives > 0
                ? $"Mario has successfully saved the princess! Lives left: {lives}"
                : $"Mario died at {rowMario};{colMario}.");

            PrintMatrix(maze);
        }

        private static void PrintMatrix(char[][] maze)
        {
            foreach (var row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool MarioMove(char[][] matrix, string command, ref int row, ref int col, ref int lives)
        {
            matrix[row][col] = '-';
            lives--;

            switch (command)
            {
                case "W": if (row > 0) { row--; } break;
                case "S": if (row < matrix.Length - 1) { row++; } break;
                case "A": if (col > 0) { col--; } break;
                case "D": if (col < matrix[row].Length - 1) { col++; } break;
            }

            if (matrix[row][col] == 'P')
            {
                matrix[row][col] = '-';
                return true;
            }

            if (matrix[row][col] == 'B')
            {
                lives -= 2;
            }

            if (lives <= 0)
            {
                matrix[row][col] = 'X';
                return false;
            }

            matrix[row][col] = 'M';
            return false;
        }

        private static void SpawnEnemy(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'B';
        }

        private static void CreateMatrix(char[][] matrix, ref int rowMario, ref int colMario)
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }
        }
    }
}