using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char input1 = Char.Parse(Console.ReadLine());
            char input2 = Char.Parse(Console.ReadLine());

            PrintCharsBetween(input1, input2);
        }

        static void PrintCharsBetween(char startChar, char endChar)
        {
            if (startChar < endChar)
            {
                for (int i = startChar + 1; i < endChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = endChar + 1; i < startChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
