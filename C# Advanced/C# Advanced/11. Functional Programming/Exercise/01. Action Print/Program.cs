using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);

            Console.ReadLine().Split().ToList().ForEach(print);
        }
    }
}