using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var text = Console.ReadLine().ToCharArray();
            
            for (int i = 0; i < text.Length; i++)
            {
                var symbol = (char)(text[i]+3);
                sb.Append(symbol);
            }

            Console.WriteLine(sb);
        }
    }
}
