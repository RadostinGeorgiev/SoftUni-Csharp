using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine($"{Calculator(firstNumber, secondNumber, operation):f2}");
        }

        static double Calculator(double input1, double input2, char oper)
        {
            switch (oper)
            {
                case '+':
                    return input1 + input2;
                    break;
                case '-':
                    return input1 - input2;
                    break;
                case '*':
                    return input1 * input2;
                    break;
                case '/':
                    if (input2 == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return input1 / input2;
                    }
                    break;
                default: return 0;
            }
        }
    }
}
