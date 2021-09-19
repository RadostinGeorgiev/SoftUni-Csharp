using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> box = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksCounter = 1;

            int clothesInRack = 0;
            while (box.Count > 0)
            {
                if ((clothesInRack + box.Peek()) <= rackCapacity)
                {
                    clothesInRack += box.Pop();
                }
                else
                {
                    racksCounter++;
                    clothesInRack = 0;
                }
            }

            Console.WriteLine(racksCounter);
        }
    }
}
