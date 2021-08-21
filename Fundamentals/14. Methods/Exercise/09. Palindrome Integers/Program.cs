using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                Console.WriteLine(IsPalindrome(input).ToString().ToLower());
                
                input = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string input)
        {
            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
