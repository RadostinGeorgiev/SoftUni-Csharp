using System;
using System.Linq;
using System.Text;

namespace _2._Rage_Quit__3_
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToUpper();
            StringBuilder word = new StringBuilder();
            StringBuilder length = new StringBuilder();
            StringBuilder output = new StringBuilder();
            bool isDigit = false;
            int repeat = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    length.Append(text[i]);
                    isDigit = true;
                }
                else
                {
                    if (isDigit)
                    {
                        repeat = int.Parse(length.ToString());
                        for (int s = 1; s <= repeat; s++)
                        {
                            output.Append(word);
                        }
                        word.Clear();
                        length.Clear();
                    }
                    word.Append(text[i]);
                    isDigit = false;
                }
            }

            repeat = int.Parse(length.ToString());
            for (int s = 1; s <= repeat; s++)
            {
                output.Append(word);
            }

            int uniqueSymbols = output.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(output);
        }
    }
}
