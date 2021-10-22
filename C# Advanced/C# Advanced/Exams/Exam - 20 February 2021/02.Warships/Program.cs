using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            int[] attackCommands = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            FillMatrix(size, matrix, ref firstPlayerShips, ref secondPlayerShips);
            int firstPlayerTotalShips = firstPlayerShips;
            int secondPlayerTotalShips = secondPlayerShips;

            for (var i = 0; i < attackCommands.Length; i += 2)
            {
                int row = attackCommands[i];
                int col = attackCommands[i + 1];

                AttackField(matrix, row, col, ref firstPlayerShips, ref secondPlayerShips);
                if (firstPlayerShips == 0)
                {
                    int totalShipsDestroyed = firstPlayerTotalShips + secondPlayerTotalShips - secondPlayerShips;
                    Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
                else if (secondPlayerShips == 0)
                {
                    int totalShipsDestroyed = firstPlayerTotalShips + secondPlayerTotalShips - firstPlayerShips;
                    Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        private static void AttackField(char[,] matrix, int row, int col, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            if (CheckCoordinates(matrix, row, col))
            {
                char fieldChar = matrix[row, col];
                if (fieldChar != '*') { matrix[row, col] = 'X'; }

                switch (fieldChar)
                {
                    case '<':
                        firstPlayerShips--;
                        break;

                    case '>':
                        secondPlayerShips--;
                        break;

                    case '#':
                        AttackField(matrix, row - 1, col - 1, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row - 1, col, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row - 1, col + 1, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row, col - 1, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row, col + 1, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row + 1, col - 1, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row + 1, col, ref firstPlayerShips, ref secondPlayerShips);
                        AttackField(matrix, row + 1, col + 1, ref firstPlayerShips, ref secondPlayerShips);
                        break;
                }

                if (firstPlayerShips < 0) { firstPlayerShips = 0; }
                if (secondPlayerShips < 0) { secondPlayerShips = 0; }
            }
        }

        private static bool CheckCoordinates(char[,] matrix, int row, int col)
        {
            return (row >= 0) && (row < matrix.GetLength(0)) && (col >= 0) && (col < matrix.GetLength(1));
        }

        private static void FillMatrix(int size, char[,] matrix, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (currentRow[col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }
        }
    }
}