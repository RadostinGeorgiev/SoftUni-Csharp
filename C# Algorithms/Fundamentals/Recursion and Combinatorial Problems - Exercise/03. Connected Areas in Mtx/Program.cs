namespace _03._Connected_Areas_in_Mtx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
    class Program
    {
        private static char[,] matrix;
        private const char VisitedChar = 'V';
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            CreateMatrix(rows, cols);
            var areas = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Area area = new () { Row = row, Col = col, Size = 0 };

                    ExploreArea(area, row, col);

                    if (area.Size != 0)
                    {
                        areas.Add(area);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");

            var index = 0;
            foreach (var area in areas.OrderByDescending(a => a.Size)
                         .ThenBy(a => a.Row)
                         .ThenBy(a => a.Col))
            {
                index++;
                Console.WriteLine($"Area #{index} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(Area area, int row, int col)
        {
            if (IsOutOfBounds(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            area.Size++;
            matrix[row, col] = VisitedChar;

            ExploreArea(area, row, col - 1);
            ExploreArea(area, row, col + 1);
            ExploreArea(area, row - 1, col);
            ExploreArea(area, row + 1, col);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedChar;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutOfBounds(int row, int col)
        {
            return row < 0 ||
                   row >= matrix.GetLength(0) ||
                   col < 0 ||
                   col >= matrix.GetLength(1);
        }

        private static void CreateMatrix(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow![col];
                }
            }
        }
    }
}