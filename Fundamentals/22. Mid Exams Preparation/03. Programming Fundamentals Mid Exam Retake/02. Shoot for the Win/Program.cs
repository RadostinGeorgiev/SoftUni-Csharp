using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;
            int shootedTargetsCounter = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 & index < targets.Length)
                {
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if ((i != index) && (targets[i] != -1))
                        {
                            if (targets[i] <= targets[index])
                            {
                                targets[i] += targets[index];
                            }
                            else if (targets[i] > targets[index])
                            {
                                targets[i] -= targets[index];
                            }
                        }
                    }
                    targets[index] = -1;
                    shootedTargetsCounter++;
                }
            }

            Console.WriteLine($"Shot targets: {shootedTargetsCounter} -> {string.Join(' ', targets)}");
        }
    }
}
