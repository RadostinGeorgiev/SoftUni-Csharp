using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double result = 0.00;
            string OddOrEven = "";

            if (number2 == 0 && (operation == "/" || operation == "%"))
            {
                Console.WriteLine($"Cannot divide {number1} by zero");
            }
            else
                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        OddOrEven = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{number1} + {number2} = {result} - {OddOrEven}");
                        break;

                    case "-":
                        result = number1 - number2;
                        OddOrEven = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{number1} - {number2} = {result} - {OddOrEven}");
                        break;

                    case "*":
                        result = number1 * number2;
                        OddOrEven = result % 2 == 0 ? "even" : "odd";
                        Console.WriteLine($"{number1} * {number2} = {result} - {OddOrEven}");
                        break;

                    case "/":
                        result = 1.00 * number1 / number2;
                        Console.WriteLine($"{number1} / {number2} = {result:F2}");
                        break;

                    case "%":
                        result = number1 % number2;
                        Console.WriteLine($"{number1} % {number2} = {result}");
                        break;
                }
        }
    }
}