using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commands = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Collect":
                        if (!journal.Contains(item))
                        {
                            journal.Add(item);
                        }
                        break;
                    case "Drop":
                        if (journal.Contains(item))
                        {
                            journal.Remove(item);
                        }
                        break;
                    case "Combine Items":
                        string[] items = item.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        string oldItem = items[0];
                        string newItem = items[1];
                        if (journal.Contains(oldItem))
                        {
                            journal.Insert(journal.IndexOf(oldItem) + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (journal.Contains(item))
                        {
                            journal.Remove(item);
                            journal.Add(item);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
