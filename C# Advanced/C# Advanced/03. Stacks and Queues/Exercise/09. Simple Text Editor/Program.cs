using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> stackResults = new Stack<string>();
            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];

                switch (command)
                {
                    case "1":
                        stackResults.Push(string.Join("", text));
                        string someString = commands[1];
                        text.Append(someString);
                        break;
                    case "2":
                        stackResults.Push(string.Join("", text));
                        int count = int.Parse(commands[1]);
                        text.Remove(text.Length - count, count);
                        break;
                    case "3":
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(stackResults.Pop());
                        break;
                }
            }
        }
    }
}
