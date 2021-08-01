using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = String.Empty;
            StringBuilder sb = new StringBuilder();

            while ((input = Console.ReadLine()) != "end")
            {
                for (var i = 0; i < input.Length; i++)
                {
                    sb.Append((char)(input[i] - key));
                }

                string message = sb.ToString();
                sb.Clear();

                string pattern = @".*?@(?<name>[A-Za-z]+)+(?:[^@!:>-]*)!(?<behavior>[G|N])!";
                string name = Regex.Match(message, pattern).Groups["name"].Value;
                string behavior = Regex.Match(message, pattern).Groups["behavior"].Value;
                if (behavior == "G")
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
