using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\s?\+359(-|\s)2\1\d{3}\1\d{4}\b";
            Regex regex = new Regex(patern);

            string input = Console.ReadLine();
            var matches = regex.Matches(input)
                .Cast<Match>()
                .Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
