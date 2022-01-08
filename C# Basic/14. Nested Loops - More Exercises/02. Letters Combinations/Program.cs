using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char charStart = char.Parse(Console.ReadLine());
            char charEnd = char.Parse(Console.ReadLine());
            char charSkip = char.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = charStart; i <= charEnd; i++)
            {
                for (int j = charStart; j <= charEnd; j++)
                {
                    for (int k = charStart; k <= charEnd; k++)
                    {
                        if (i != charSkip && j != charSkip && k != charSkip)
                        {
                            Console.Write($"{Convert.ToChar(i)}{Convert.ToChar(j)}{Convert.ToChar(k)} ");
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}