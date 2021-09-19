using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int, int> findMin = null;
            findMin = (array, size) => size == 1 ? (int)array[0] : Math.Min(array[size - 1], findMin(array, size - 1));

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int size = numbers.Length;
            Console.WriteLine(findMin(numbers, size));
        }
    }
}