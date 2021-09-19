using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int carsCounter = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Equals("green"))
                {
                    int availableTime = greenLightDuration;

                    while (availableTime > 0 && queue.Count > 0)
                    {
                        string car = queue.Dequeue();
                        availableTime -= car.Length;

                        if (availableTime >= 0)
                        {
                            carsCounter++;
                        }
                        else
                        {
                            availableTime += freeWindowDuration;
                            if (availableTime >= 0)
                            {
                                carsCounter++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + availableTime]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsCounter} total cars passed the crossroads.");
        }
    }
}