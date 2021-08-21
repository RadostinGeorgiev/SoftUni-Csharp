using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peoplesWaiting = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < lift.Length; i++)
            {
                int freeSpace = 4 - lift[i];
                if (peoplesWaiting < freeSpace)
                {
                    freeSpace = peoplesWaiting;
                }
                peoplesWaiting -= freeSpace;
                lift[i] += freeSpace;

                if ((peoplesWaiting == 0) && (lift[lift.Length-1] < 4))
                {
                    Console.WriteLine("The lift has empty spots!");
                    break;
                }
            }

            if (peoplesWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peoplesWaiting} people in a queue!");
            }

            Console.WriteLine(string.Join(' ', lift));
        }
    }
}
