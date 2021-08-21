using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosionStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    explosionStrength += int.Parse(input[i+1].ToString());
                }
                else
                {
                    if (explosionStrength != 0)
                    {
                        input = input.Remove(i, 1);
                        i--;
                        explosionStrength--;
                    }

                }
            }

            Console.WriteLine(input);
        }
    }
}