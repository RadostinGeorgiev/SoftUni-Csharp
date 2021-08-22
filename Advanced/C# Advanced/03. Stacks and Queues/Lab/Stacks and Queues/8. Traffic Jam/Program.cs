using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int crossings = int.Parse(Console.ReadLine());
            string car = String.Empty;
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            while ((car = Console.ReadLine()) != "end")
            {
                if (car == "green")
                {
                    int waitingCars = queue.Count;
                    for (int i = 0; i < (waitingCars < crossings ? waitingCars : crossings); i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(car);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
