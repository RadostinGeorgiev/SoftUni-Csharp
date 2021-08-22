using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (var i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(':
                        indexes.Push(i);
                        break;
                    case ')':
                        Console.WriteLine(expression.Substring(indexes.Peek(), i - indexes.Pop() + 1));
                        break;
                }
            }
        }
    }
}
