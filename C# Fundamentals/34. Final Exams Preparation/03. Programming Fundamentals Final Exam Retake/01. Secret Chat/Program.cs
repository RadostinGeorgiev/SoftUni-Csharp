using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] commands = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                int index = 0;
                string substring = String.Empty;

                switch (command)
                {
                    case "InsertSpace":
                        index = int.Parse(commands[1]);

                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        substring = commands[1];

                        if (message.Contains(substring))
                        {
                            index = message.IndexOf(substring);
                            message = message.Remove(index, substring.Length);
                            message += new string(substring.Reverse().ToArray());
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        substring = commands[1];
                        string replacement = commands[2];

                        while (message.Contains(substring))
                        {
                            message = message.Replace(substring, replacement);
                        }

                        Console.WriteLine(message);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
