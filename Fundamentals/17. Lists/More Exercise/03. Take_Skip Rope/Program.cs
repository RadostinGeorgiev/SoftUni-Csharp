using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> encryptedMessage = Console.ReadLine()
                .ToCharArray()
                .ToList();
            List<int> numbers = new List<int>();

            for (int i = 0; i < encryptedMessage.Count; i++)
            {
                int digit = 0;
                if (int.TryParse(encryptedMessage[i].ToString(), out digit)) //char.IsDigit()
                {
                    numbers.Add(digit);
                    encryptedMessage.RemoveAt(i);
                    i--;
                }
            }

            string nonNumbersMessage = string.Join("", encryptedMessage);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            StringBuilder result = new StringBuilder();

            int currentPosition = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                if (currentPosition + takeList[i] <= nonNumbersMessage.Length)
                {
                    result.Append(nonNumbersMessage.Substring(currentPosition, takeList[i]));
                }
                else
                {
                    result.Append(nonNumbersMessage.Substring(currentPosition));
                }

                currentPosition += takeList[i] + skipList[i];
            }

            Console.WriteLine(result);
        }
    }
}
