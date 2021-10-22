using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> orcs = null;

            for (int attack = 1; attack <= waves; attack++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (attack != 0 && attack % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int currentPlate = plates.Dequeue();
                    int currentOrc = orcs.Pop();

                    if (currentOrc > currentPlate)
                    {
                        currentOrc -= currentPlate;
                        orcs.Push(currentOrc);
                    }
                    else if (currentOrc < currentPlate)
                    {
                        currentPlate -= currentOrc;
                        var tempList = plates.ToList();
                        tempList.Insert(0, currentPlate);
                        plates = new Queue<int>(tempList);
                    }
                }

                if (plates.Count == 0) { break; }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", plates));
            }
            else
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.Write("Orcs left: ");
                Console.WriteLine(string.Join(", ", orcs));
            }
        }
    }
}