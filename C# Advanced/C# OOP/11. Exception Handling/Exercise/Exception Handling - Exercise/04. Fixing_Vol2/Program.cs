using System;

namespace _04._Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result = 0;

            firstNumber = 30;
            secondNumber = 60;

            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            Console.ReadLine();
        }
    }
}