using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());
            int bulletsCosts = 0;
            int shots = 0;

            while ((bullets.Count > 0) && (locks.Count > 0))
            {
                bulletsCosts += bulletPrice;
                shots++;
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if ((shots % barrelSize == 0) && (bullets.Count > 0))
                {
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine(locks.Count == 0
                ? $"{bullets.Count} bullets left. Earned ${intelligence - bulletsCosts}"
                : $"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
