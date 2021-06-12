using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Substract(Sum(number1, number2), number3));
        }

        static int Sum(int input1, int input2)
        {
            return input1 + input2;
        }

        static int Substract(int input1, int input2)
        {
            return input1 - input2;
        }
    }
}
