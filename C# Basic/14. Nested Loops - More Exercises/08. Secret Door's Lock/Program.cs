using System;

namespace _08._Secret_Door_s_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundredsLimit = int.Parse(Console.ReadLine());
            int tensLimit = int.Parse(Console.ReadLine());
            int unitsLimit = int.Parse(Console.ReadLine());

            for (int hundreds = 2; hundreds <= hundredsLimit; hundreds += 2)
            {
                for (int tens = 2; tens <= tensLimit; tens++)
                {
                    bool tensIsPrime = true;
                    for (int i = 2; i * i <= tens; i++)
                    {
                        if (tens % i == 0) tensIsPrime = false;
                    }

                    if (tensIsPrime)
                    {
                        for (int units = 2; units <= unitsLimit; units += 2)
                        {
                            Console.WriteLine($"{hundreds} {tens} {units}");
                        }
                    }
                }
            }
        }
    }
}