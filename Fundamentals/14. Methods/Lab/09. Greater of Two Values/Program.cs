
using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfInput = Console.ReadLine();

            if (typeOfInput == "int")
            {
                int input1 = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }
            else if (typeOfInput == "char")
            {
                char input1 = char.Parse(Console.ReadLine());
                char input2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }
            else if (typeOfInput == "string")
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                Console.WriteLine(GetMax(input1, input2));
            }

        }

        static int GetMax(int input1, int input2)
        {
            int result = input1.CompareTo(input2);
            if (result > 0)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }

        static char GetMax(char input1, char input2)
        {
            int result = input1.CompareTo(input2);
            if (result > 0)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }

        static string GetMax(string input1, string input2)
        {
            int result = input1.CompareTo(input2);
            if (result > 0)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }
    }
}
