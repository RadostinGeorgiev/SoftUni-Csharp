using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandName = command[0];
                int index = 0;

                switch (commandName)
                {
                    case "Add":
                        string particle = command[1];
                        index = int.Parse(command[2]);

                        if ((index >= 0) && (index < parts.Count))
                        {
                            parts.Insert(index, particle);
                        }
                        break;
                    case "Remove":
                        index = int.Parse(command[1]);

                        if ((index >= 0) && (index < parts.Count))
                        {
                            parts.RemoveAt(index);
                        }
                        break;
                    case "Check":
                        string where = command[1];
                        if (where == "Even")
                        {
                            StringBuilder outputEven = new StringBuilder();
                            outputEven.Clear();
                            for (int i = 0; i < parts.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    outputEven.Append(parts[i] + ' ');
                                }
                            }
                            outputEven.ToString().TrimEnd();
                            Console.WriteLine(outputEven);
                        }
                        else
                        {
                            StringBuilder outputOdd = new StringBuilder();
                            outputOdd.Clear();
                            for (int i = 0; i < parts.Count; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    outputOdd.Append(parts[i] + ' ');
                                }
                            }
                            outputOdd.ToString().TrimEnd();
                            Console.WriteLine(outputOdd);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", parts)}!");
        }
    }
}
