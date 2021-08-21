using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());

            if (n1 < n2 && n2 < n3)
            {
                Console.Write($"{n3}\n{n2}\n{n1}\n");
            }
            else if (n2 <= n1 && n1 <= n3)
            {
                Console.Write($"{n3}\n{n1}\n{n2}\n");
            }
            else if (n3 <= n1 && n1 <= n2)
            {
                Console.Write($"{n2}\n{n1}\n{n3}\n");
            }
            else if (n1 <= n3 && n3 <= n2)
            {
                Console.Write($"{n2}\n{n3}\n{n1}\n");
            }
            else if (n2 <= n3 && n3 <= n1)
            {
                Console.Write($"{n1}\n{n3}\n{n2}\n");
            }
            else if (n3 <= n2 && n2 <= n1)
            {
                Console.Write($"{n1}\n{n2}\n{n3}\n");
            }
        }
    }
}