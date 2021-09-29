using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> guests = new Queue<int>(
                Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());
            Stack<int> plates = new Stack<int>(
                Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());

            int wastedFood = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {
                int currentGuest = guests.Peek();
                int currentPlate = plates.Pop();

                while (currentGuest > 0)
                {
                    currentGuest -= currentPlate;
                    if (currentGuest <= 0)
                    {
                        wastedFood -= currentGuest;
                        guests.Dequeue();
                    }
                    else
                    {
                        currentPlate = plates.Pop();
                    }
                }
            }

            Console.WriteLine(plates.Count > 0 ?
                $"Plates: {string.Join(' ', plates)}" :
                $"Guests: {string.Join(' ', guests)}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}