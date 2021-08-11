using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string commandName = command[0];
                string phone = string.Empty;

                switch (commandName)
                {
                    case "Add":
                        phone = command[1];
                        if (!phones.Contains(phone))
                        {
                            phones.Add(phone);
                        }
                        break;
                    case "Remove":
                        phone = command[1];
                        if (phones.Contains(phone))
                        {
                            phones.Remove(phone);
                        }
                        break;
                    case "Bonus phone":
                        string[] items = command[1]
                            .Split(':', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        string oldPhone = items[0];
                        string newPhone = items[1];

                        if (phones.Contains(oldPhone))
                        {
                            int index = phones.IndexOf(oldPhone);
                            phones.Insert(index+1, newPhone);
                        }
                        break;
                    case "Last":
                        phone = command[1];
                        if (phones.Contains(phone))
                        {
                            phones.Remove(phone);
                            phones.Add(phone);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
