using System;

namespace PetsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNumber = int.Parse(Console.ReadLine());
            int animalsNumber = int.Parse(Console.ReadLine());
            double expenses = dogsNumber * 2.5 + animalsNumber * 4;
 
            Console.WriteLine($"{expenses} lv.");
        }
    }
}