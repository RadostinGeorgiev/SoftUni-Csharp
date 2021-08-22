using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split();
                string command = commands[0];
                int value = int.Parse(commands[1]);

                switch (command)
                {
                    case "Add":
                        numbers.Add(value);
                        break;
                    case "Remove":
                        numbers.Remove(value);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(value);
                        break;
                    case "Insert":
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, value);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
