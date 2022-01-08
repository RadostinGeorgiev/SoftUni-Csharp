namespace _06._8_Queens_Puzzle
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    class Program
    {
        private const int Size = 8;
        private static char[,] chessboard;

//      private static readonly HashSet<int> RowsSet = new HashSet<int>(); //all queens are placed consecutively at rows 0…7
        private static readonly HashSet<int> ColsSet = new HashSet<int>();
        private static readonly HashSet<int> LeftDiagonalSet = new HashSet<int>();
        private static readonly HashSet<int> RightDiagonalSet = new HashSet<int>();

        private static int queensCounter = 0;

        static void Main(string[] args)
        {
            CreateChessboard(Size, Size);

            PutQueen(0);
        }

        private static void PutQueen(int row)
        {
            if (row == chessboard.GetLength(0)
                && queensCounter == Size)
            {
                PrintChessboard();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (!IsFree(row, col)) continue;

                MarkPosition(row, col);
                PutQueen(row + 1);
                UnMarkPosition(row, col);
            }
        }

        private static bool IsFree(int row, int col)
        {
//          var isRowFree = !RowsSet.Contains(row);
            var isColFree = !ColsSet.Contains(col);
            var isLeftDiagonalFree = !LeftDiagonalSet.Contains(col - row);
            var isRightDiagonalFree = !RightDiagonalSet.Contains(row + col);

            return /*isRowFree &&*/ isColFree && isLeftDiagonalFree && isRightDiagonalFree;
        }

        private static void UnMarkPosition(int row, int col)
        {
            chessboard[row, col] = '-';

//          RowsSet.Remove(row);
            ColsSet.Remove(col);
            LeftDiagonalSet.Remove(col - row);
            RightDiagonalSet.Remove(row + col);

            queensCounter--;
        }

        private static void MarkPosition(int row, int col)
        {
            chessboard[row, col] = '*';

//          RowsSet.Add(row);
            ColsSet.Add(col);
            LeftDiagonalSet.Add(col - row);
            RightDiagonalSet.Add(row + col);

            queensCounter++;
        }

        private static void PrintChessboard()
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    Console.Write(chessboard[row, col].ToString() + ' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void CreateChessboard(int chessboardRows, int chessboardCols)
        {
            chessboard = new char[chessboardRows, chessboardCols];

            for (int row = 0; row < chessboardRows; row++)
            {
                for (int col = 0; col < chessboardCols; col++)
                {
                    chessboard[row, col] = '-';
                }
            }
        }
    }
}