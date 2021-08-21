using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
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
                string[] commandString = input.Split();
                string command = commandString[0];
                int element = int.Parse(commandString[1]);

                if (command == "Delete")
                {
                    numbers.RemoveAll(item => item == element);
                }
                else if (command == "Insert")
                {
                    int position = int.Parse(commandString[2]);
                    numbers.Insert(position, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
