using System;

namespace OddOrEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number % 2 == 0 ? "even" : "odd");
        }
    }
}