using System;
using System.Collections.Generic;
using System.Text.Json;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();
            string content = Console.ReadLine();

            string comment = Console.ReadLine();
            List<string> comments = new List<string>();

            while (comment != "end of comments")
            {
                comments.Add(comment);

                comment = Console.ReadLine();
            }

            Console.WriteLine($"<h1>{Environment.NewLine}    {article}{Environment.NewLine}</h1>");
            Console.WriteLine($"<article>{Environment.NewLine}    {content}{Environment.NewLine}</article>");
            foreach (var s in comments)
            {
                Console.WriteLine($"<div>{Environment.NewLine}    {s}{Environment.NewLine}</div>");
            }
        }
    }
}
