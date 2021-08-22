using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    AddNumbers(number1, number2);
                    break;
                case "multiply":
                    MultiplyNumbers(number1, number2);
                    break;
                case "subtract":
                    SubtractNumbers(number1, number2);
                    break;
                case "divide":
                    DivideNumbers(number1, number2);
                    break;
            }

            static void AddNumbers(int input1, int input2)
            {
                Console.WriteLine(input1 + input2);
            }

            static void MultiplyNumbers(int input1, int input2)
            {
                Console.WriteLine(input1 * input2);
            }

            static void SubtractNumbers(int input1, int input2)
            {
                Console.WriteLine(input1 - input2);
            }

            static void DivideNumbers(int input1, int input2)
            {
                Console.WriteLine(input1 / input2);
            }

        }
    }
}
