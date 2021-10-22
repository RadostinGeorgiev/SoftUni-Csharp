using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (tasks.Count > 0)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToBeKilled}");
                    break;
                }
                
                threads.Dequeue();
                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                }
            }

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}