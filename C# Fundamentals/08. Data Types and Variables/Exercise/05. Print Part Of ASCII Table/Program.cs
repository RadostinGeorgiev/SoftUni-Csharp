using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstASCIICode = int.Parse(Console.ReadLine());
            int lastASCIICode = int.Parse(Console.ReadLine());

            for (int i = firstASCIICode; i <= lastASCIICode; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
