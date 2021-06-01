using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beerKegs = int.Parse(Console.ReadLine());
            double biggestVolume = 0;
            string biggestType = "";

            for (int i = 1; i <= beerKegs; i++)
            {
                string typeOfKeg = Console.ReadLine();
                double radiusOfKeg = double.Parse(Console.ReadLine());
                int heightOfKeg = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radiusOfKeg, 2) * heightOfKeg;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestType = typeOfKeg;
                }

            }

            Console.WriteLine(biggestType);
        }
    }
}
