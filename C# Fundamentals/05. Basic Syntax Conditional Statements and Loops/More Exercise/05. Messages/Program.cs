using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtSMS = int.Parse(Console.ReadLine());
            string outputSMS = "";

            for (int i = 0; i < lenghtSMS; i++)
            {
                string currentSymbolCode = Console.ReadLine();
                int mainDigit = int.Parse(currentSymbolCode[0].ToString());

                if (mainDigit == 0)
                {
                    outputSMS += " ";
                }
                else
                {
                    int offset = (mainDigit - 2) * 3;
                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset++;
                    }

                    int index = (offset + currentSymbolCode.Length - 1);
                    outputSMS += (char)('a' + index);
                }
            }

            Console.WriteLine(outputSMS);
        }
    }
}