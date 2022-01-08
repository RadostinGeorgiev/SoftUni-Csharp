using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber > secondNumber ? firstNumber : secondNumber);
        }
    }
}