using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<string> result = new List<string>();

            int memory = 0;
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(firstNumber[i].ToString()) * secondNumber + memory;
                memory = currentDigit / 10;
                currentDigit %= 10;
                result.Add(currentDigit.ToString());
            }

            if (memory > 0)
            {
                result.Add(memory.ToString());
            } 

            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
