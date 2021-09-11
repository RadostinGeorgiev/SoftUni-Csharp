using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, 
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Where(word=> char.IsUpper(word[0]))));
        }
    }
}
