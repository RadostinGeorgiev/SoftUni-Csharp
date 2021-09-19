using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int number = int.Parse(Console.ReadLine());

            Func<int, int, bool> filter = (x, n) => x % n != 0;
            numbers = numbers.Where(x=> filter(x, number)).ToArray();

            Console.WriteLine(string.Join(' ', numbers.Reverse()));
        }
    }
}