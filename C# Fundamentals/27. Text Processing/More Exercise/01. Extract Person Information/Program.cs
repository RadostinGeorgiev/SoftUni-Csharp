using System;
using System.Text.RegularExpressions;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"@(?<name>\w+)\|";
            string agePattern = @"#(?<age>[0-9]+)\*";

            int numberRows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberRows; i++)
            {
                string text = Console.ReadLine();

                var nameMatch = Regex.Match(text, namePattern);
                var ageMatch = Regex.Match(text, agePattern);

                Console.WriteLine($"{nameMatch.Groups["name"].Value} is {ageMatch.Groups["age"].Value} years old.");
            }
        }
    }
}
