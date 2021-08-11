using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] commands = input.Split().ToArray();
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Urgent":
                        if (!shoppingList.Contains(item))
                        {
                            shoppingList.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Remove(item);
                        }
                        break;
                    case "Correct":
                        string newName = commands[2];
                        if (shoppingList.Contains(item))
                        {
                            shoppingList[shoppingList.IndexOf(item)] = newName;
                        }
                        break;
                    case "Rearrange":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Remove(item);
                            shoppingList.Add(item);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
