using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] command = input.Split();
                switch (command[0])
                {
                    case "exchange":
                        ExchangeByIndex(array, int.Parse(command[1]));
                        break;
                    case "max":
                        IndexOfMaxOddOrEven(array, command[1]);
                        break;
                    case "min":
                        IndexOfMinOddOrEven(array, command[1]);
                        break;
                    case "first":
                        FirstOddOrEven(array, int.Parse(command[1]), command[2]);
                        break;
                    case "last":
                        LastOddOrEven(array, int.Parse(command[1]), command[2]);
                        break;
                }

            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static void ExchangeByIndex(int[] inputArray, int index)
        {
            if ((index >= 0) && (index <= inputArray.Length - 1))
            {

                for (int movements = 0; movements <= index; movements++)
                {
                    int firstElement = inputArray[0];
                    for (int i = 0; i < inputArray.Length - 1; i++)
                    {
                        inputArray[i] = inputArray[i + 1];
                    }

                    inputArray[inputArray.Length - 1] = firstElement;
                }
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        static void IndexOfMaxOddOrEven(int[] inputArray, string OddOrEven)
        {
            int isOdd = 1;
            if (OddOrEven.ToLower() == "odd")
            {
                isOdd = 0;
            }

            int maxNumber = int.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if ((inputArray[i] % 2 != isOdd) && (inputArray[i] >= maxNumber))
                {
                    maxNumber = inputArray[i];
                    maxIndex = i;
                }
            }

            if (maxNumber == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        static void IndexOfMinOddOrEven(int[] inputArray, string OddOrEven)
        {
            int isOdd = 1;
            if (OddOrEven.ToLower() == "odd")
            {
                isOdd = 0;
            }

            int minNumber = int.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if ((inputArray[i] % 2 != isOdd) && (inputArray[i] <= minNumber))
                {
                    minNumber = inputArray[i];
                    minIndex = i;
                }
            }

            if (minNumber == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        static void FirstOddOrEven(int[] inputArray, int items, string OddOrEven)
        {
            if (items > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int isOdd = 1;
            if (OddOrEven.ToLower() == "odd")
            {
                isOdd = 0;
            }

            string output = "";
            int currentItem = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 != isOdd)
                {
                    output += inputArray[i] + " ";
                    currentItem++;
                }

                if (currentItem == items)
                {
                    break;
                }
            }


            if (currentItem != 0)
            {
                int[] result = output
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }

        }

        static void LastOddOrEven(int[] inputArray, int items, string OddOrEven)
        {
            if (items > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int isOdd = 1;
            if (OddOrEven.ToLower() == "odd")
            {
                isOdd = 0;
            }

            string output = "";
            int currentItem = 0;

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                if (inputArray[i] % 2 != isOdd)
                {
                    output += inputArray[i] + " ";
                    currentItem++;
                }

                if (currentItem == items)
                {
                    break;
                }
            }


            if (currentItem != 0)
            {
                int[] result = output
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }

        }
    }
}
