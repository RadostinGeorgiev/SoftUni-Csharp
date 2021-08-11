using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] commands = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string substring = commands[2];

                        if ((index >= 0) && (index < text.Length))
                        {
                            text = text.Insert(index, substring);
                        }
                        break;
                    case "Remove Stop":
                        int indexStart = int.Parse(commands[1]);
                        int indexEnd = int.Parse(commands[2]);

                        if ((indexStart >= 0) && (indexStart < text.Length)
                                              && (indexEnd >= 0) && (indexEnd < text.Length))
                        {
                            text = text.Remove(indexStart, indexEnd - indexStart + 1);
                        }
                        break;
                    case "Switch":
                        string oldSubstring = commands[1];
                        string newSubstring = commands[2];
                        if ((oldSubstring != newSubstring) && (text.Contains(oldSubstring)))
                        {
                            text = text.Replace(oldSubstring, newSubstring);
                        }
                        break;
                }

                Console.WriteLine(text);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
