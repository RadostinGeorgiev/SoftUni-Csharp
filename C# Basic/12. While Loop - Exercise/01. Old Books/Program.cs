using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int checkedBooks = 0;
            string currentBook = Console.ReadLine();

            while (currentBook != "No More Books")
            {
                if (currentBook == bookName)
                {
                    Console.WriteLine($"You checked {checkedBooks} books and found it.");
                    break;
                }
                checkedBooks++;
                currentBook = Console.ReadLine();
            }

            if (currentBook == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {checkedBooks} books.");
            }


        }
    }
}
