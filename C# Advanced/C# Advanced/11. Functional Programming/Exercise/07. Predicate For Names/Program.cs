using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<string, int, bool> filter = (x, n) => x.Length <= n;

            Console.ReadLine()
                .Split()
                .Where(x => filter(x, length))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}