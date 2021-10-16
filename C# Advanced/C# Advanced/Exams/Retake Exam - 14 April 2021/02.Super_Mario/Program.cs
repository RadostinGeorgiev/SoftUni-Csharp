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

            bool isWin = false;
            while (lives > 0)
            {

                var command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int rowE = int.Parse(command[1]);
                int colE = int.Parse(command[2]);
                SpawnEnemy(maze, rowE, colE);

                isWin = MarioMove(maze, command[0], ref rowMario, ref colMario, ref lives);
                if (isWin) { break; }
            }

            Console.WriteLine(isWin
                ? $"Mario has successfully saved the princess! Lives left: {lives}"
                : $"Mario died at {rowMario};{colMario}.");

            PrintMatrix(maze);
        }

        private static void SpawnEnemy(char[][] maze, int row, int col)
        {
            maze[row][col] = 'B';
        }

        private static void CreateMatrix(char[][] maze, ref int rowMario, ref int colMario)
        {
            for (var row = 0; row < maze.Length; row++)
            {
                maze[row] = Console.ReadLine().ToCharArray();

                for (var col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] maze)
        {
            foreach (var row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool MarioMove(char[][] maze, string command, ref int rowMario, ref int colMario, ref int lives)
        {
            maze[rowMario][colMario] = '-';
            lives--;

            switch (command)
            {
                case "W":
                    if (rowMario > 0) { rowMario--; }
                    break;

                case "S":
                    if (rowMario < maze.Length - 1) { rowMario++; }
                    break;
                case "A":
                    if (colMario > 0) { colMario--; }
                    break;
                case "D":
                    if (colMario < maze[rowMario].Length - 1) { colMario++; }
                    break;
            }

            if (maze[rowMario][colMario] == 'P')
            {
                maze[rowMario][colMario] = '-';
                return true;
            }

            if (maze[rowMario][colMario] == 'B')
            {
                lives -= 2;
            }

            if (lives <= 0)
            {
                maze[rowMario][colMario] = 'X';
                return false;
            }

            maze[rowMario][colMario] = 'M';
            return false;
        }
    }
}