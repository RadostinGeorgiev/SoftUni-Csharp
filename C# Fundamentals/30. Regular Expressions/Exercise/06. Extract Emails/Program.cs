using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(?<=\s)([A-Za-z0-9]+([.-]\w*)*\@[A-Za-z]+([.-][A-Za-z]*)*(\.[A-Za-z]{2,}))";

            Console.WriteLine(string.Join(Environment.NewLine, Regex.Matches(text, pattern)));
        }
    }
}
