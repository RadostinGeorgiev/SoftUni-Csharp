using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upLimit = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            Func<int, int, bool> filter = (i, n) => i % n == 0;
            List<int> result = new List<int>();
            
            for (int i = 1; i <= upLimit; i++)
            {
                bool isDivided = true;
                foreach (var divider in dividers)
                {
                    if (!filter(i, divider))
                    {
                        isDivided = false;
                    }
                }

                if (isDivided)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}