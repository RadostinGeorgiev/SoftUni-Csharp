using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string dataType = "";

            while (input != "END")
            {
                if (int.TryParse(input, out _))
                {
                    dataType = "integer";
                }
                else if (double.TryParse(input, out _))
                {
                    dataType = "floating point";
                }
                else if (char.TryParse(input, out _))
                {
                    dataType = "character";
                }
                else if (bool.TryParse(input, out _))
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{input} is {dataType } type");
                input = Console.ReadLine();
            }
        }
    }
}
