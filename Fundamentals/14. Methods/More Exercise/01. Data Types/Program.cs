using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(PrintResult(input));
            }
            else if (type == "real")
            {
                double input = double.Parse(Console.ReadLine());
                Console.WriteLine($"{PrintResult(input):f2}");
            }
            else if (type == "string")
            {
                string input = Console.ReadLine();
                Console.WriteLine(PrintResult(input));
            }
        }

        static int PrintResult(int input)
        {
            return input * 2;
        }

        static double PrintResult(double input)
        {
            return input * 1.5;
        }

        static string PrintResult(string input)
        {
            return "$" + input + "$";
        }
    }
}
