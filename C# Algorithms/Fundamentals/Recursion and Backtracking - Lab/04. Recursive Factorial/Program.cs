namespace _04._Recursive_Factorial
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorialRecursively(number));
        }

        private static int GetFactorialRecursively(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * GetFactorialRecursively(number - 1);
        }
    }
}