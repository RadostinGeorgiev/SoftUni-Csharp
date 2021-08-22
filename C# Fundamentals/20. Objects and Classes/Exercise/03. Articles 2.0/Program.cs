using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberCommands = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 1; i <= numberCommands; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string criteria = Console.ReadLine().ToLower();

            switch (criteria)
            {
                case "title":
                    articles.OrderBy(a => a.Title).ToList().ForEach(a => Console.WriteLine(a.ToString()));
                    break;
                case "content":
                    articles.OrderBy(a => a.Content).ToList().ForEach(a => Console.WriteLine(a.ToString()));
                    break;
                case "author":
                    articles.OrderBy(a => a.Author).ToList().ForEach(a => Console.WriteLine(a.ToString()));
                    break;
            }
        }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
