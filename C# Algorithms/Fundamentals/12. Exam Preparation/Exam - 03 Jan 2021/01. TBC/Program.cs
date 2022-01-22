namespace _01._TBC
{
    using System;

    class Program
    {
        public static char[,] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            ReadMatrix(rows, cols, matrix);

            var tunnelCounter = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsVisited(row, col) || IsDirth(row, col)) continue;

                    ExploreTunnel(row, col);
                    tunnelCounter++;
                }
            }

            Console.WriteLine(tunnelCounter);
        }

        private static void ExploreTunnel(int row, int col)
        {
            if (!IsInBound(row, col)) return;

            if (IsVisited(row, col) || IsDirth(row, col)) return;
            
            MarkField(row, col);

            ExploreTunnel(row, col + 1);
            ExploreTunnel(row + 1, col + 1);
            ExploreTunnel(row + 1, col);
            ExploreTunnel(row + 1, col - 1);
            ExploreTunnel(row, col - 1);
            ExploreTunnel(row - 1, col - 1);
            ExploreTunnel(row - 1, col);
            ExploreTunnel(row - 1, col + 1);
        }

        private static bool IsInBound(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   (col >= 0 && col < matrix.GetLength(1));
        }

        private static void MarkField(int row, int col)
        {
            matrix[row, col] = 'V';
        }

        private static bool IsDirth(int row, int col)
        {
            return matrix[row, col] == 'd';
        }
        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == 'V';
        }

        private static void ReadMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}