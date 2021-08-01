using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < input.Length; i++)
            {
                bool isValud = !((input[i].Length < 3) || (input[i].Length > 16));

                if (isValud)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (!((char.IsDigit(input[i][j])) ||
                              (char.IsLetter(input[i][j])) ||
                              (input[i][j] == '-') ||
                              (input[i][j] == '_')))
                        {
                            isValud = false;
                            break;
                        }
                    }
                }

                if (isValud)
                {
                    Console.WriteLine(input[i]);
                }
            }
        }
    }
}
