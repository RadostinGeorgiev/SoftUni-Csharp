using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int battleCounter = 0;

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battleCounter} won battles and {energy} energy");
                    return;
                }

                energy -= distance;
                battleCounter++;

                if (battleCounter % 3 == 0)
                {
                    energy += battleCounter;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battleCounter}. Energy left: {energy}");
        }
    }
}
