using System;

namespace _02.Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 8;
            const int cols = 8;

            char[,] chessBoard = new char[rows, cols];
            int[] whitePawn = new int[2];
            int[] blackPawn = new int[2];
            FillMatrix(rows, cols, chessBoard, ref whitePawn, ref blackPawn);

            while (whitePawn[0] != 0 && blackPawn[0] != 7)
            {
                int result = MoveWhitePawn(chessBoard, ref whitePawn, ref blackPawn);
                if (result == 1)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)('a' + whitePawn[1])}{8}.");
                    break;
                }
                if (result == -1)
                {
                    Console.WriteLine($"Game over! White capture on {(char)('a' + whitePawn[1])}{8 - whitePawn[0]}.");
                    break;
                };

                result = MoveBlackPawn(chessBoard, ref whitePawn, ref blackPawn);
                if (result == 1)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)('a' + blackPawn[1])}{1}.");
                    break;
                }
                if (result == -1)
                {
                    Console.WriteLine($"Game over! Black capture on {(char)('a' + blackPawn[1])}{8 - blackPawn[0]}.");
                    break;
                };
            }
        }

        private static bool AttackPawn(ref int[] player, int[] target, int[] attacked)
        {
            if (attacked[0] == target[0] && attacked[1] == target[1])
            {
                player[0] = attacked[0];
                player[1] = attacked[1];
                return true;
            }

            return false;
        }

        private static int MoveBlackPawn(char[,] chessBoard, ref int[] white, ref int[] black)
        {
            int[] attack = new int[2];
            attack[0] = black[0] + 1;
            attack[1] = black[1] - 1;
            if (CheckCoordinate(chessBoard, attack[0], attack[1]) &&
               (AttackPawn(ref black, white, attack)))
                return -1;

            attack[1] = black[1] + 1;
            if (CheckCoordinate(chessBoard, attack[0], attack[1]) &&
               (AttackPawn(ref black, white, attack)))
                return -1;

            chessBoard[black[0], black[1]] = '-';
            black[0]++;
            chessBoard[black[0], black[1]] = 'b';

            if (black[0] == 7)
            {
                return 1;
            }

            return 0;
        }

        private static int MoveWhitePawn(char[,] chessBoard, ref int[] white, ref int[] black)
        {
            int[] attack = new int[2];
            attack[0] = white[0] - 1;
            attack[1] = white[1] - 1;
            if (CheckCoordinate(chessBoard, attack[0], attack[1]) &&
                (AttackPawn(ref white, black, attack)))
                return -1;

            attack[1] = white[1] + 1;
            if (CheckCoordinate(chessBoard, attack[0], attack[1]) &&
                (AttackPawn(ref white, black, attack)))
                return -1;

            chessBoard[white[0], white[1]] = '-';
            white[0]--;
            chessBoard[white[0], white[1]] = 'w';

            if (white[0] == 0)
            {
                return 1;
            }

            return 0;
        }

        private static bool CheckCoordinate(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(int rows, int cols, char[,] matrix, ref int[] white, ref int[] black)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'w')
                    {
                        white[0] = row;
                        white[1] = col;
                    }
                    if (currentRow[col] == 'b')
                    {
                        black[0] = row;
                        black[1] = col;
                    }
                }
            }
        }
    }
}