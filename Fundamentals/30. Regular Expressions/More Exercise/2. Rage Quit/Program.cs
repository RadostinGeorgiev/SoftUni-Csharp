using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\D+)([0-9]+)";
            StringBuilder sb = new StringBuilder();

            foreach (Match match in Regex.Matches(text, pattern, RegexOptions.Compiled))
            {
                string piece = match.Groups[1].Value;
                int repeat = int.Parse(match.Groups[2].Value);
                for (int i = 1; i <= repeat; i++)
                {
                    sb.Append(piece.ToUpper());
                }
            }

            int uniqueSymbols = sb.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(sb);
        }
    }
}
