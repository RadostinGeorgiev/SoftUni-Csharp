using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numberAsText = number.ToString();
            double sum = 0.0;

            for (int i = 0; i <= numberAsText.Length - 1; i++)
            {
                byte currentDigit = byte.Parse(numberAsText[i].ToString());

                int factorial = 1;
                for (int j = 1; j <= currentDigit; j++)
                {
                    factorial *= j;
                }

                sum += factorial;
            }

            Console.WriteLine(sum == number ? "yes" : "no");
        }
    }
}