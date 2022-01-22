namespace _01._Fibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(number));
        }

        private static long Fibonacci(int number)
        {
            if (cache.ContainsKey(number)) return cache[number];

            if (number < 2) return number;

            var result = Fibonacci(number - 2) + Fibonacci(number - 1);
            cache[number] = result;
            return result;
        }
    }
}