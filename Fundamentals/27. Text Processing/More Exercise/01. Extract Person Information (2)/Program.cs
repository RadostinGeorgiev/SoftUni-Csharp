using System;

namespace _01._Extract_Person_Information__2_
{
    class Program
    {
        static void Main(string[] args)
        {
            char charNameStart = '@';
            char charNameEnd = '|';
            char charAgeStart = '#';
            char charAgeEnd = '*';

            int numberRows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberRows; i++)
            {
                string text = Console.ReadLine();

                int indexNameStart = text.IndexOf(charNameStart);
                int indexNameEnd = text.IndexOf(charNameEnd);
                string name = text.Substring(indexNameStart + 1, indexNameEnd - indexNameStart - 1);

                int indexAgeStart = text.IndexOf(charAgeStart);
                int indexAgeEnd = text.IndexOf(charAgeEnd);
                string age = text.Substring(indexAgeStart + 1, indexAgeEnd - indexAgeStart - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
