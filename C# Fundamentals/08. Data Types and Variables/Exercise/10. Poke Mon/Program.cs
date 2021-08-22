using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int startPowerOfPokeMon = int.Parse(Console.ReadLine());
            int distanceToTarget = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int powerOfPokeMon = startPowerOfPokeMon;
            int pockedCounter = 0;

            while (powerOfPokeMon >= distanceToTarget)
            {
                pockedCounter++;
                powerOfPokeMon -= distanceToTarget;

                if (powerOfPokeMon == startPowerOfPokeMon * 0.5 && exhaustionFactor != 0)
                {
                    powerOfPokeMon /= exhaustionFactor;
                }
            }

            Console.WriteLine(powerOfPokeMon);
            Console.WriteLine(pockedCounter);
        }
    }
}
