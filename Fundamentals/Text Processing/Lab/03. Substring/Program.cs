using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringFirst = Console.ReadLine();
            string stringSecond = Console.ReadLine();

            while (stringSecond.Contains(stringFirst))
            {
                stringSecond = stringSecond.Remove(stringSecond.IndexOf(stringFirst), stringFirst.Length);
            }
            Console.WriteLine(stringSecond);
        }
    }
}
