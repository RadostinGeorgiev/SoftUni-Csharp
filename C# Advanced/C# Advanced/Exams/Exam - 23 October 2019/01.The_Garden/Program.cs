using System;
using System.Linq;

namespace _01.The_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] garden = new char[rows][];
            int countOfCucmbers = 0;
            int countOfPotatos = 0;
            int countOfCarrots = 0;
            int harmedVegetables = 0;

            FillMatrix(rows, garden);

            string input;
            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] commandInfo = input.Split();
                string command = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);

                switch (command)
                {
                    case "Harvest":
                        HarvestVegetable(garden, ref countOfCucmbers, ref countOfPotatos, ref countOfCarrots, row, col);
                        break;

                    case "Mole":
                        string direction = commandInfo[3];

                        MoleAttack(garden, row, col, direction, ref harmedVegetables);
                        break;
                }
            }

            PrintMatrix(garden);
            Console.WriteLine($"Carrots: {countOfCarrots}");
            Console.WriteLine($"Potatos: {countOfPotatos}");
            Console.WriteLine($"Lettuce: {countOfCucmbers}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static void PrintMatrix(char[][] garden)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                Console.WriteLine(string.Join(' ', garden[row]));
            }
        }

        private static void MoleAttack(char[][] garden, int row, int col, string direction, ref int harmedVegetables)
        {
            switch (direction)
            {
                case "up":
                    for (int i = row; i >= 0; i -= 2)
                    {
                        HarmVegetable(garden, i, col, ref harmedVegetables);
                    }
                    break;
                case "down":
                    for (int i = 0; i < garden.Length; i += 2)
                    {
                        HarmVegetable(garden, i, col, ref harmedVegetables);
                    }
                    break;
                case "left":
                    for (int i = col; i >= 0; i -= 2)
                    {
                        HarmVegetable(garden, row, i, ref harmedVegetables);
                    }
                    break;
                case "right":
                    for (int i = 0; i < garden[row].Length; i += 2)
                    {
                        HarmVegetable(garden, row, i, ref harmedVegetables);
                    }
                    break;
            }
        }

        private static void HarmVegetable(char[][] garden, int row, int col, ref int harmedVegetables)
        {
            if (char.IsLetter(garden[row][col]))
            {
                harmedVegetables++;
            }

            garden[row][col] = ' ';
        }

        private static void HarvestVegetable(char[][] garden, ref int countOfCucmbers, ref int countOfPotatos, ref int countOfCarrots, int row, int col)
        {
            if (CheckCoordinate(garden, row, col))
            {
                char vegetable = garden[row][col];
                switch (vegetable)
                {
                    case 'L': countOfCucmbers++; break;
                    case 'P': countOfPotatos++; break;
                    case 'C': countOfCarrots++; break;
                }

                garden[row][col] = ' ';
            }
        }

        private static bool CheckCoordinate(char[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length;
        }

        private static void FillMatrix(int rows, char[][] garden)
        {
            for (int row = 0; row < rows; row++)
            {
                garden[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }
        }
    }
}
