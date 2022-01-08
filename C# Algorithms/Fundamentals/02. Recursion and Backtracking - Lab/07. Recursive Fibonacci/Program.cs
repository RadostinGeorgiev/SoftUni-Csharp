namespace _07._Recursive_Fibonacci
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        private static int GetFibonacci(int n)
        {
            if (n <=1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}