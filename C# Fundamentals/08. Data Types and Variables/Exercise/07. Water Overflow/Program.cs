using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int tankVolume = 255;
            int readedValues = int.Parse(Console.ReadLine());
            int freeVolume = tankVolume;
            int filledVolume = 0;

            for (int i = 1; i <= readedValues; i++)
            {
                int currentLiters = int.Parse(Console.ReadLine());

                if (currentLiters > freeVolume)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    freeVolume -= currentLiters;
                    filledVolume += currentLiters;
                }
            }

            Console.WriteLine(filledVolume);
        }
    }
}
