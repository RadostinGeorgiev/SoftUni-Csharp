using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int armyPosRow = 0;
            int armyPosCol = 0;

            CreateMatrix(matrix, ref armyPosRow, ref armyPosCol);

            bool isWin = false;
            while (armor > 0)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int enemySpawnRow = int.Parse(commandArgs[1]);
                int enemySpawnCol = int.Parse(commandArgs[2]);
                SpawnEnemy(matrix, enemySpawnRow, enemySpawnCol);

                isWin = MoveArmy(direction, matrix, ref armyPosRow, ref armyPosCol, ref armor);
                if (isWin) { break; }
            }

            Console.WriteLine(isWin
                ? $"The army managed to free the Middle World! Armor left: {armor}"
                : $"The army was defeated at {armyPosRow};{armyPosCol}.");

            PrintMatrix(matrix);
        }

        private static void CreateMatrix(char[][] matrix, ref int armyPosRow, ref int armyPosCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyPosRow = row;
                        armyPosCol = col;
                    }
                }
            }
        }

        private static void SpawnEnemy(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'O';
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var c in matrix)
            {
                Console.WriteLine(string.Join("", c));
            }
        }

        private static bool MoveArmy(string direction, char[][] matrix, ref int row, ref int col, ref int armor)
        {
            matrix[row][col] = '-';
            armor--;

            switch (direction)
            {
                case "up":
                    if (row > 0) { row--; }
                    break;
                case "down":
                    if (row < matrix.Length - 1) { row++; }
                    break;
                case "left":
                    if (col > 0) { col--; }
                    break;
                case "right":
                    if (col < matrix[row].Length - 1) { col++; }
                    break;
            }

            if (matrix[row][col] == 'M')
            {
                matrix[row][col] = '-';
                return true;
            }

            if (matrix[row][col] == 'O')
            {
                armor -= 2;
            }

            if (armor <= 0)
            {
                matrix[row][col] = 'X';
                return false;
            }

            matrix[row][col] = 'A';
            return false;
        }

    }
}