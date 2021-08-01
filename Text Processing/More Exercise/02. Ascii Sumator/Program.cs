using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char charStart = char.Parse(Console.ReadLine());
            char charEnd = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] > Math.Min(charStart, charEnd)) && (text[i] < Math.Max(charStart, charEnd)))
                {
                    sum += text[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
