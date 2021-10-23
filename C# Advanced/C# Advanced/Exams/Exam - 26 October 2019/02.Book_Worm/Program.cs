using System;
using System.Data;
using System.Text;

namespace _02.Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int rowP = 0;
            int colP = 0;

            FillMatrix(size, matrix, ref rowP, ref colP);
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                MovePlayer(matrix, command, ref rowP, ref colP);
                ActionPlayer(sb, matrix, rowP, colP);
            }

            Console.WriteLine(sb.ToString().Trim());
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

        private static void ActionPlayer(StringBuilder sb, char[,] matrix, int row, int col)
        {
            if (TryLeftMatrix(matrix, ref row, ref col) && sb.Length >= 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            if (matrix[row, col] != '-')
            {
                sb.Append(matrix[row, col]);
            }

            matrix[row, col] = 'P';
        }

        private static void MovePlayer(char[,] matrix, string command, ref int row, ref int col)
        {
            matrix[row, col] = '-';

            switch (command)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
            }
        }

        private static bool TryLeftMatrix(char[,] matrix, ref int row, ref int col)
        {
            if (row < 0)
            {
                row = 0;
                return true;
            }

            if (row == matrix.GetLength(0))
            {
                row = matrix.GetLength(0) - 1;
                return true;
            }

            if (col < 0)
            {
                col = 0;
                return true;
            }

            if (col == matrix.GetLength(1))
            {
                col = matrix.GetLength(1) - 1;
                return true;
            }

            return false;
        }

        private static void FillMatrix(int size, char[,] matrix, ref int rowP, ref int colP)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'P')
                    {
                        rowP = row;
                        colP = col;
                    }
                }
            }
        }
    }
}
