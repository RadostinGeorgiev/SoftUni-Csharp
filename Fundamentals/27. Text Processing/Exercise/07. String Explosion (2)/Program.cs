using System;
using System.Text;

namespace _07._String_Explosion__2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int explosionStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    sb.Append(input[i]);
                    explosionStrength += int.Parse(input[i+1].ToString());
                }
                else
                {
                    if (explosionStrength != 0)
                    {
                        explosionStrength--;
                    }
                    else
                    {
                        sb.Append(input[i]);
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
