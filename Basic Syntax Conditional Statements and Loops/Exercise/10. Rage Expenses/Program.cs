using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            int trashedHeadsets = lostGames / 2;
            int trashedMouses = lostGames / 3;
            int trashedKeyboards = lostGames / 6;
            int trashedDisplays = lostGames / 12;

            double totalExpenses = trashedHeadsets * priceHeadset + trashedMouses * priceMouse +
                                   trashedKeyboards * priceKeyboard + trashedDisplays * priceDisplay;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}