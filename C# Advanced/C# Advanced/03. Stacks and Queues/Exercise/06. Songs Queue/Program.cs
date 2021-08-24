using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count > 0)
            {
                Queue<string> commands = new Queue<string>(Console.ReadLine().Split());
                string command = commands.Dequeue();

                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string song = string.Join(' ', commands);
                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
