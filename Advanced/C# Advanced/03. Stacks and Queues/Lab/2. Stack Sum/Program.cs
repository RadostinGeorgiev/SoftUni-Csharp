using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();
                string command = commands[0];

                switch (command.ToLower())
                {
                    case "add":
                        stack.Push(int.Parse(commands[1]));
                        stack.Push(int.Parse(commands[2]));
                        break;
                    case "remove":
                        int repeats = int.Parse(commands[1]);
                        if (repeats <= stack.Count)
                        {
                            for (var i = 0; i < int.Parse(commands[1]); i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
