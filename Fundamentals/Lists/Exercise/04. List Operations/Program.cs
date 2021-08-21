using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
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
            while (input != "End")
            {
                string[] commands = input.Split();
                string command = commands[0];
                int value = 0;

                switch (command)
                {
                    case "Add":
                        value = int.Parse(commands[1]);
                        numbers.Add(value);
                        break;
                    case "Insert":
                        value = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        if (index >= 0 && index <= numbers.Count)
                        {
                            numbers.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        value = int.Parse(commands[1]);

                        if (value >= 0 && value <= numbers.Count)
                        {
                            numbers.RemoveAt(value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        string direction = commands[1];
                        value = int.Parse(commands[2]);

                        if (direction == "left")
                        {
                            for (int i = 0; i < value; i++)
                            {
                                int firstItem = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(firstItem);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < value; i++)
                            {
                                int lastIndex = numbers.Count - 1;
                                int lastItem = numbers[lastIndex];
                                numbers.RemoveAt(lastIndex);
                                numbers.Insert(0, lastItem);
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
