using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daiLyYield = startingYield;
            int daysCounter = 0;
            int spicesInStore = 0;

            while (daiLyYield >= 100)
            {
                daysCounter++;
                spicesInStore += daiLyYield - 26;
                daiLyYield -= 10;
            }

            spicesInStore -= 26;

            if (spicesInStore < 0)
            {
                spicesInStore = 0;
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(spicesInStore);
        }
    }
}
