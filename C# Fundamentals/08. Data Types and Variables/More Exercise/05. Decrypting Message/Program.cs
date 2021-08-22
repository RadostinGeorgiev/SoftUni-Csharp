using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte rows = byte.Parse(Console.ReadLine());
            string output = "";

            for (byte i = 0; i < rows; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                output += (char)(currentSymbol + key);
            }
            
            Console.WriteLine(output);
        }
    }
}
