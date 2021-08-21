using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumsInitialQuality = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> drumsQuality = new List<int>();
            foreach (var item in drumsInitialQuality)
            {
                drumsQuality.Add(item);
            }

            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    drumsQuality[i] -= hitPower;

                    if (drumsQuality[i] <= 0)
                    {
                        int drumPrice = drumsInitialQuality[i] * 3;
                        if (savings >= drumPrice)
                        {
                            drumsQuality[i] = drumsInitialQuality[i];
                            savings -= drumPrice;
                        }
                        else
                        {
                            drumsQuality.RemoveAt(i);
                            drumsInitialQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', drumsQuality));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
