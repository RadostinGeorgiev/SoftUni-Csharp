using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Push")
                {
                    myStack.Push(command.Skip(1).Select(int.Parse).ToArray());
                }
                else if (command[0] == "Pop")
                {
                    myStack.Pop();
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}