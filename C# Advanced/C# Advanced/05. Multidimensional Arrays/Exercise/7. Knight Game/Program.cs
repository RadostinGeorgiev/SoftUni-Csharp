using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = CreateSquareMatrix(size);

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int maxAttacksIndexRow = 0;
                int maxAttacksIndexCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attacks = PossibleAttacks(board, row, col);
                            if (attacks > maxAttacks)
                            {
                                maxAttacks = attacks;
                                maxAttacksIndexRow = row;
                                maxAttacksIndexCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    break;
                }

                board[maxAttacksIndexRow, maxAttacksIndexCol] = '0';
                removedKnights++;
            }

            Console.WriteLine(removedKnights);
        }

        private static char[,] CreateSquareMatrix(int size)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = currentRow[col];
                }
            }

            return board;
        }

        private static bool CheckCoordinate(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }

        private static void CheckAttack(char[,] board, int row, int col, ref int counter)
        {
            if (CheckCoordinate(board, row, col) && board[row, col] == 'K')
            {
                counter++;
            }
        }

        private static int PossibleAttacks(char[,] board, int row, int col)
        {
            int counter = 0;
            CheckAttack(board, row + 1, col + 2, ref counter);
            CheckAttack(board, row - 1, col + 2, ref counter);
            CheckAttack(board, row + 1, col - 2, ref counter);
            CheckAttack(board, row - 1, col - 2, ref counter);
            CheckAttack(board, row + 2, col + 1, ref counter);
            CheckAttack(board, row - 2, col + 1, ref counter);
            CheckAttack(board, row + 2, col - 1, ref counter);
            CheckAttack(board, row - 2, col - 1, ref counter);

            return counter;
        }
    }
}
