using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bottleCapacity = 750;
            const int necessaryForDishes = 5;
            const int necessaryForPot = 15;

            int washing = 0;
            int dishes = 0;
            int pots = 0;

            int bottles = int.Parse(Console.ReadLine());
            int restDetergent = bottles * bottleCapacity;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int currentItems = int.Parse(command);
                washing++;

                if (washing % 3 == 0)
                {
                    restDetergent -= currentItems * necessaryForPot;
                    pots += currentItems;
                }
                else
                {
                    restDetergent -= currentItems * necessaryForDishes;
                    dishes += currentItems;
                }

                if (restDetergent < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(restDetergent)} ml. more necessary!");
                    return;
                }
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
            Console.WriteLine($"Leftover detergent {restDetergent} ml.");
        }
    }
}