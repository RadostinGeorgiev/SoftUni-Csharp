using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredSum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> GetCharactersSum = (s, i) => s.ToCharArray().Select(x=>(int)x).Sum() >= i;

            Console.WriteLine(names.First(s => GetCharactersSum(s, requiredSum)));
        }
    }
}
