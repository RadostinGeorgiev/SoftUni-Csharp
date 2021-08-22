using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0);
            Queue<int> numbers = new Queue<int>(input);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
