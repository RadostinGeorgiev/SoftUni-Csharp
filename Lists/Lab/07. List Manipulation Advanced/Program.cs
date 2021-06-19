using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
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
            bool isChanged = false;

            while (input != "end")
            {
                string[] commands = input.Split();
                string command = commands[0];

                switch (command)
                {
                    case "Add":
                        int value = int.Parse(commands[1]);
                        numbers.Add(value);
                        isChanged = true;
                        break;
                    case "Remove":
                        value = int.Parse(commands[1]);
                        numbers.Remove(value);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        value = int.Parse(commands[1]);
                        numbers.RemoveAt(value);
                        isChanged = true;
                        break;
                    case "Insert":
                        value = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, value);
                        isChanged = true;
                        break;
                    case "Contains":
                        value = int.Parse(commands[1]);
                        if (numbers.Contains(value))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(' ', numbers.FindAll(i => i % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(' ', numbers.FindAll(i => i % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string condition = commands[1];
                        value = int.Parse(commands[2]);

                        switch (condition)
                        {
                            case "<":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n < value)));
                                break;
                            case ">":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n > value)));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n >= value)));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n <= value)));
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }

        }
    }
}
