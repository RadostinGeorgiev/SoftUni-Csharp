using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ValidatePassword(password);
        }

        static void ValidatePassword(string input)
        {
            bool isValid = true;

            if (!CheckStringLength(input, 6, 10))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!CheckSymbolsRange(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!CheckMinDigits(input, 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckStringLength(string input, int minLength, int maxLength)
        {
            if (input.Length >= minLength && input.Length <= maxLength)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool CheckSymbolsRange(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                bool isDigit = (currentChar >= 48) && (currentChar <= 57);
                bool isCapitalLetter = (currentChar >= 65) && (currentChar <= 90);
                bool isSmallLeter = (currentChar >= 97) && (currentChar <= 122);

                if (!(isDigit || isCapitalLetter || isSmallLeter))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckMinDigits(string input, int minDigits)
        {
            int digitCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if ((currentChar >= 48) && (currentChar <= 57))
                {
                    digitCounter++;
                }
            }

            if (digitCounter >= minDigits)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
