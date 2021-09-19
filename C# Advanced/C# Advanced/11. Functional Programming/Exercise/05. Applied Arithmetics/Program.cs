using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        public delegate int Operation(int item, int number);
        public delegate int[] Processor(int[] arr, Operation operation, int number);

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Operation add = (x, number) => x + number;
            Operation substract = (x, number) => x - number;
            Operation multiply = (x, number) => x * number;
            Processor processing = (arr, oper, number) => arr.Select(x => oper(x, number)).ToArray();
            Action<int[]> print = arr => Console.WriteLine(string.Join(' ', arr));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = processing(numbers, add, 1);
                        break;
                    case "multiply":
                        numbers = processing(numbers, multiply, 2);
                        break;
                    case "subtract":
                        numbers = processing(numbers, substract, 1);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}