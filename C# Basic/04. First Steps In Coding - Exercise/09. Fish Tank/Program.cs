using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int width  = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int depth = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            int volume = width * height * depth;
            double liters = volume * 0.001;
            double water = liters * (1 - percentage / 100);

            Console.WriteLine(water);
        }
    }
}