using System;
using System.Diagnostics.Tracing;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 1;
            bool isFinish = false;

            for (int rows = 1; rows <= number; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    if (counter <= number)
                    {
                        Console.Write($"{counter} ");
                        counter++;
                    }
                    else
                    {
                        isFinish = true;
                        break;
                    }
                }

                if (isFinish) break;

                Console.WriteLine();
            }
        }
    }
}