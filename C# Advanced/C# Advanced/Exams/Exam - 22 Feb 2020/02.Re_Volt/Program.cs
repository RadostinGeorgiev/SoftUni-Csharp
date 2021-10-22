using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numberCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int rowP = 0;
            int colP = 0;

            FillMatrix(size, matrix, ref rowP, ref colP);
            bool isWin = false;

            for (int i = 1; i <= numberCommands; i++)
            {
                string command = Console.ReadLine();
                isWin = ActionPlayer(matrix, command, ref rowP, ref colP);

                if (isWin) { break; }
            }

            Console.WriteLine(isWin ? "Player won!" : "Player lost!");
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

        private static bool ActionPlayer(char[,] matrix, string command, ref int row, ref int col)
        {
            int rowC = row;
            int colC = col;
            MovePlayer(matrix, command, ref row, ref col, 1);

            if (matrix[row, col] == 'B')
            {
                MovePlayer(matrix, command, ref row, ref col, 1);
            }
            else if (matrix[row, col] == 'T')
            {
                MovePlayer(matrix, command, ref row, ref col, -1);
            }

            matrix[rowC, colC] = '-';
            if (matrix[row, col] == 'F')
            {
                matrix[row, col] = 'f';
                return true;
            }

            matrix[row, col] = 'f';
            return false;
        }

        private static void MovePlayer(char[,] matrix, string command, ref int row, ref int col, int direction)
        {
            switch (command)
            {
                case "up": row -= direction; break;
                case "down": row += direction; break;
                case "left": col -= direction; break;
                case "right": col += direction; break;
            }

            NecessaryTeleport(matrix, ref row, ref col);
        }

        private static void NecessaryTeleport(char[,] matrix, ref int row, ref int col)
        {
            if (row < 0) { row = matrix.GetLength(0) - 1; }
            if (row == matrix.GetLength(0)) { row = 0; }
            if (col < 0) { col = matrix.GetLength(1) - 1; }
            if (col == matrix.GetLength(1)) { col = 0; }
        }

        private static void FillMatrix(int size, char[,] matrix, ref int rowP, ref int colP)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        rowP = row;
                        colP = col;
                    }
                }
            }
        }
    }
}