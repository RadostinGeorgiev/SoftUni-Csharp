using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> comparator = (numFirst, numSecond) =>
            {
                if (numFirst % 2 == 0 && numSecond % 2 != 0)
                {
                    return -1;
                }
                else if (numFirst % 2 != 0 && numSecond % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return numFirst.CompareTo(numSecond);
                }
            };

            Comparison<int> comparison = new Comparison<int>(comparator);
            Array.Sort(numbers, comparison);
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}