using System;
using System.Text;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] commands = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "Move":
                        int numberOfLetters = int.Parse(commands[1]);

                        string substring = message.ToString().Substring(0, numberOfLetters);
                        message.Remove(0, numberOfLetters);
                        message.Append(substring);
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];

                        message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string oldString = commands[1];
                        string newString = commands[2];

                        while (message.ToString().Contains(oldString))
                        {
                            message.Replace(oldString, newString);
                        }
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
