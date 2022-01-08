using System;

namespace _12._The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNumber = int.Parse(Console.ReadLine());

            int passwordCounter = 0;
            string password = "";

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if ((a * b + c * d == controlNumber) && (a < b) && (c > d))
                            {
                                passwordCounter++;
                                Console.Write($"{a}{b}{c}{d} ");
                                if (passwordCounter == 4)
                                {
                                    password = Convert.ToString(a) + 
                                               Convert.ToString(b) + 
                                               Convert.ToString(c) + 
                                               Convert.ToString(d);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(password == "" ? "No!" : $"Password: {password}");
        }
    }
}