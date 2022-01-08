namespace _05._Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static readonly List<char> Path = new List<char>();
        private static char[,] lab;

        static void Main(string[] args)
        {
            lab = ReadLab();
            FindPath(0, 0, 'S');
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            Path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) &&
                IsFree(row, col))
            {
                Mark(row, col);
                FindPath(row, col + 1, 'R');
                FindPath(row, col - 1, 'L');
                FindPath(row - 1, col, 'U');
                FindPath(row + 1, col, 'D');
                UnMark(row, col);
            }

            Path.RemoveAt(Path.Count - 1);
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join(string.Empty,Path.Skip(1)));
        }

        private static void UnMark(int row, int col)
        {
            lab[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            lab[row, col] = 'v';
        }

        private static bool IsVisited(int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static bool IsFree(int row, int col)
        {
            return lab[row, col] == '-';
        }

        private static bool IsExit(int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsInBounds(int row, int col)
        {
            var isRowExist = row >= 0 && row <= lab.GetLength(0) - 1;
            var isColExist = col >= 0 && col <= lab.GetLongLength(1) - 1;

            return isRowExist && isColExist;
        }

        private static char[,] ReadLab()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] arr = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = currentRow[col];
                }
            }

            return arr;
        }
    }
}