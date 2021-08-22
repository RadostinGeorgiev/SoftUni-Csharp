using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(expression);

            while (stack.Count > 1)
            {
                int operandFirst = int.Parse(stack.Pop());
                char operation = char.Parse(stack.Pop());
                int operandSecond = int.Parse(stack.Pop());

                switch (operation)
                {
                    case '+':
                        stack.Push((operandFirst + operandSecond).ToString());
                        break;
                    case '-':
                        stack.Push((operandFirst - operandSecond).ToString());

                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
