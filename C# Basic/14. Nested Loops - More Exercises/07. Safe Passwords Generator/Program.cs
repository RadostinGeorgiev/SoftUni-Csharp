using System;

namespace _07._Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswordsNumber = int.Parse(Console.ReadLine());

            int asciiA = 35;
            int asciiB = 64;
            int currentPasswordNumber = 0;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{Convert.ToChar(asciiA)}{Convert.ToChar(asciiB)}{x}{y}{Convert.ToChar(asciiB)}{Convert.ToChar(asciiA)}|");

                    asciiA++;
                    if (asciiA > 55) asciiA = 35;

                    asciiB++;
                    if (asciiB > 96) asciiB = 64;

                    currentPasswordNumber++;
                    if (currentPasswordNumber >= maxPasswordsNumber) return;
                }
            }
        }
    }
}