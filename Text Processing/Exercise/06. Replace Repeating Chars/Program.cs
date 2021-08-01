using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            sb.Append(input[0]);
            for (int i = 0; i < input.Length - 1; i++)
            {
                
                if (input[i] != input[i+1])
                {
                    sb.Append(input[i + 1]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
