using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine($"Sir {s}");

            Console.ReadLine().Split().ToList().ForEach(print);
        }
    }
}