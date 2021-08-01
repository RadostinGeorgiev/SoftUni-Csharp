using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberCommands; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];

                switch (command)
                {
                    case "Edit":
                        string newContent = commands[1];
                        article.Edit(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = commands[1];
                        article.ChangeAuthor(newAuthor);
                        break;
                    case "Rename":
                        string newTitle = commands[1];
                        article.Rename(newTitle);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    public class Article
    {
        private string Title { get; set; }
        private string Content { get; set; }
        private string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
